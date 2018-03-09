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
using TechDebtTypes;

namespace TechDebt
{
   
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TechDebtAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(Rules.Value.Values.Concat(new[] { riskRule, issueRule, diagRule }).ToArray());
            }
        }

        static Lazy<Dictionary<Smell, DiagnosticDescriptor>> Rules = new Lazy<Dictionary<Smell, DiagnosticDescriptor>>
        (
            () =>  SmellType.Descriptors
                               .ToDictionary
                                (
                                 x=>x.Key, 
                                 x => new DiagnosticDescriptor(x.Key.ToString(), x.Value.Title, "{0}", "Tech Debt", DiagnosticSeverity.Info, true, x.Value.Description)
                                )
        );

        static DiagnosticDescriptor riskRule = new DiagnosticDescriptor("Risk", "Risk", "{0}", "Risk", DiagnosticSeverity.Info, true, "");
        static DiagnosticDescriptor issueRule = new DiagnosticDescriptor("Issue", "Issue", "{0}", "Issue", DiagnosticSeverity.Info, true, "");
        static DiagnosticDescriptor diagRule = new DiagnosticDescriptor("Diag", "Diag", "{0}", "Diag", DiagnosticSeverity.Info, true, "");

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;
            var loc = namedTypeSymbol.Locations[0];
            var tda = context.Symbol.GetAttributes().ToArray();

            //diag
            var fa = tda.FirstOrDefault(x => x.AttributeClass.Name == "SmellAttribute");
            if(fa != null)
            {
                context.ReportDiagnostic(Diagnostic.Create(diagRule, loc, fa.AttributeClass.ToDisplayString()));
            }

            var df = tda.FirstOrDefault(x => context.Compilation.GetTypeByMetadataName(typeof(SmellAttribute).FullName) == x.AttributeClass);
            if (df != null)
            {
                var dca = df.ConstructorArguments;
                var code = (Smell)dca[0].Value;
                var rule = Rules.Value[code];
                var props = new Dictionary<String, String>
                {
                    { "gap", dca[2].Value.ToString() }
                };
                var diagnostic = Diagnostic.Create(rule, loc, props.ToImmutableDictionary(), dca[1].Value as String);
                context.ReportDiagnostic(diagnostic);
            }

            var df2 = tda.FirstOrDefault(x =>  context.Compilation.GetTypeByMetadataName(typeof(RiskAttribute).FullName) == x.AttributeClass);
            if (df2 != null)
            {
                var dca = df2.ConstructorArguments;
                var props = new Dictionary<String, String>
                {
                    { "gap", dca[1].Value.ToString() }
                };
                var diagnostic = Diagnostic.Create(riskRule, loc, props.ToImmutableDictionary(), dca[0].Value as String);
                context.ReportDiagnostic(diagnostic);
            }

            var df3 = tda.FirstOrDefault(x => context.Compilation.GetTypeByMetadataName(typeof(IssueAttribute).FullName) == x.AttributeClass);
            if (df3 != null)
            {
                var dca = df3.ConstructorArguments;
                var props = new Dictionary<String, String>
                {
                    { "gap", dca[1].Value.ToString() }
                };
                var diagnostic = Diagnostic.Create(issueRule, loc, props.ToImmutableDictionary(), dca[0].Value as String);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
