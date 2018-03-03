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

namespace IronicTechDebt
{
   
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TechDebtAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return ImmutableArray.Create(Rules.Value.Values.Concat(new[] { diagRule }).ToArray());
            }
        }

        static Lazy<Dictionary<TechDebtCode, DiagnosticDescriptor>> Rules = new Lazy<Dictionary<TechDebtCode, DiagnosticDescriptor>>
        (
            () =>  TechDebtType.Descriptors
                               .ToDictionary
                                (
                                 x=>x.Key, 
                                 x => new DiagnosticDescriptor(x.Key.ToString(), x.Value.Title, "{0}", "Tech Debt", DiagnosticSeverity.Info, true, x.Value.Description)
                                )
        );

        static DiagnosticDescriptor diagRule = new DiagnosticDescriptor("Diagnostic", "Diag", "{0}", "Diag", DiagnosticSeverity.Info, true, "Desc");

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;
            var loc = namedTypeSymbol.Locations[0];
            var tda = context.Symbol.GetAttributes().ToArray();
            var df = tda.FirstOrDefault(x => x.AttributeClass.Name == "TechDebtAttribute");
            if (df != null)
            {
                //context.ReportDiagnostic(Diagnostic.Create(diagRule, loc, "Found Attribute Check again"));
                var dca = df.ConstructorArguments;
                //context.ReportDiagnostic(Diagnostic.Create(diagRule, loc, String.Format("ca lenth is {0}", dca.Length)));
                if (dca.Length == 2)
                {
                   // context.ReportDiagnostic(Diagnostic.Create(diagRule, loc, String.Format("dca0 {0}", dca[0].Value)));
                    //if (dca[0].Value != null)
                      //  context.ReportDiagnostic(Diagnostic.Create(diagRule, loc, String.Format("dca0 value is {0}", ((TechDebtCode)dca[0].Value).ToString())));
                    if (dca[0].Value is int)
                    {
                        //context.ReportDiagnostic(Diagnostic.Create(diagRule, loc, String.Format("dca1 {0}", dca[1].Value)));
                        if (dca[1].Value is String)
                        {
                          //  context.ReportDiagnostic(Diagnostic.Create(diagRule, loc, "Found correct args"));
                            var code = (TechDebtCode)dca[0].Value;
                            var rule = Rules.Value[code];
                            var diagnostic = Diagnostic.Create(rule, loc, dca[1].Value as String,);
                            context.ReportDiagnostic(diagnostic);
                        }
                    }
                }
            }
        }
    }
}
