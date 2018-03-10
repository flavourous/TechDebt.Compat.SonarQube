using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Diagnostics;
using System.IO;

namespace TechDebt.Compat.SonarQube
{
   
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TechDebtAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(Rules.Value.Values.Concat(new[] { riskRule, issueRule }).ToArray());
            }
        }

        static Lazy<Dictionary<Smell, DiagnosticDescriptor>> Rules = new Lazy<Dictionary<Smell, DiagnosticDescriptor>>
        (
            () => SmellType.Descriptors
                               .ToDictionary
                                (
                                 x => x.Key,
                                 x => new DiagnosticDescriptor(x.Key.ToString(), x.Value.Title, "{0}", "Tech Debt", DiagnosticSeverity.Info, true, x.Value.Description)
                                )
        );

        static DiagnosticDescriptor riskRule = new DiagnosticDescriptor("Risk", "Risk", "{0}", "Risk", DiagnosticSeverity.Info, true, "");
        static DiagnosticDescriptor issueRule = new DiagnosticDescriptor("Issue", "Issue", "{0}", "Issue", DiagnosticSeverity.Info, true, "");

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }
    
        static object[] Check(INamedTypeSymbol s, String name, params Type[] args)
        {
            var atr = s.GetAttributes().ToArray();
            var mat = atr.FirstOrDefault(a =>
            {
                if (a.AttributeClass.Name != name) return false;
                if (a.ConstructorArguments.Count() != args.Length) return false;
                for(int i=0;i<args.Length;i++)
                {
                    var val = a.ConstructorArguments[i].Value;
                    if (val == null) return false;
                    if (val.GetType() != args[i]) return false;
                }
                return true;
            });
            return mat == null ? null : mat.ConstructorArguments.Select(x => x.Value).ToArray();
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;
            var loc = namedTypeSymbol.Locations[0];

            context.ReportDiagnostic(Diagnostic.Create(issueRule, loc, "Everything"));

            var df = Check(namedTypeSymbol, "Smell", typeof(int), typeof(String), typeof(double));
            if (df != null)
            {
                var code = (Smell)df[0];
                var rule = Rules.Value[code];
                var props = new Dictionary<String, String>
                {
                    { "gap", (String)df[2] }
                };
                var diagnostic = Diagnostic.Create(rule, loc, props.ToImmutableDictionary(), (String)df[1]);
                context.ReportDiagnostic(diagnostic);
            }

            var df2 = Check(namedTypeSymbol, "Risk", typeof(String), typeof(double));
            if (df2 != null)
            {
                var props = new Dictionary<String, String>
                {
                    { "gap", (String)df[1] }
                };
                var diagnostic = Diagnostic.Create(riskRule, loc, props.ToImmutableDictionary(), (String)df[0]);
                context.ReportDiagnostic(diagnostic);
            }

            var df3 = Check(namedTypeSymbol, "Issue", typeof(String), typeof(double));
            if (df3 != null)
            {
                var props = new Dictionary<String, String>
                {
                    { "gap", (String)df[1] }
                };
                var diagnostic = Diagnostic.Create(issueRule, loc, props.ToImmutableDictionary(), (String)df[0]);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
