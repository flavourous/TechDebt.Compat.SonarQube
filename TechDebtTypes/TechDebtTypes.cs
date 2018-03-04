using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechDebtTypes;
using System.Threading.Tasks;

namespace TechDebtTypes
{
    public class TechDebtAttribute : Attribute
    {
        public TechDebtAttribute(TechDebtCode type, String reason, double effort) { }
    }
    public class TechDebtType
    {
        private TechDebtType() { }
        public String Title { get; private set; }
        public String Description { get; private set; }

        public static readonly IReadOnlyDictionary<TechDebtCode, TechDebtType> Descriptors = new Dictionary<TechDebtCode, TechDebtType>
        {
            { TechDebtCode.DEBT_ABBREVIATIONS_USAGE, new TechDebtType { Title = "ABBREVIATIONS_USAGE", Description="Confusing abbreviations are being used instead of explicit names." } },
            { TechDebtCode.DEBT_ANTI_PATTERN, new TechDebtType { Title = "ANTI_PATTERN", Description="An anti-pattern has been used." } },
            { TechDebtCode.DEBT_BAD_DESIGN, new TechDebtType { Title = "BAD_DESIGN", Description="The design is really bad and should be improved." } },
            { TechDebtCode.DEBT_BAD_FRAMEWORK_USAGE, new TechDebtType { Title = "BAD_FRAMEWORK_USAGE", Description="A framework is not used the way it should." } },
            { TechDebtCode.DEBT_BAD_LOGGING, new TechDebtType { Title = "BAD_LOGGING", Description="The logging message, level, is inappropriate or the log is redundant." } },
            { TechDebtCode.DEBT_HOW_COMMENT, new TechDebtType { Title = "HOW_COMMENT", Description="The comment or documentation text focuses on the 'how' instead of the why" } },
            { TechDebtCode.DEBT_INDECENT_EXPOSURE, new TechDebtType { Title = "INDECENT_EXPOSURE", Description="The class unnecessarily exposes its internals. Aggressively refactor classes to minimize its public surface. You should have a compelling reason for every item you make public. If you don't, hide it." } },
            { TechDebtCode.DEBT_MEANINGLESS_COMMENT, new TechDebtType { Title = "MEANINGLESS_COMMENT", Description="The comment or javadoc should be reviewed: it makes no sense or does not seem to be related to the code !" } },
            { TechDebtCode.DEBT_MIDDLE_MAN, new TechDebtType { Title = "MIDDLE_MAN", Description="The class delegates all its work, is it really needed ? Cut out the middle man unless you really need a wrapper." } },
            { TechDebtCode.DEBT_MISSING_IMPLEMENTATION, new TechDebtType { Title = "MISSING_IMPLEMENTATION", Description="A method's implementation is missing." } },
            { TechDebtCode.DEBT_MISSING_TEST, new TechDebtType { Title = "MISSING_TEST", Description="An important test is missing." } },
            { TechDebtCode.DEBT_MISSING_DOCUMENTATION, new TechDebtType { Title = "MISSING_DOCUMENTATION", Description="An important documentation is missing." } },
            { TechDebtCode.DEBT_MULTIPLE_RESPONSIBILITIES, new TechDebtType { Title = "MULTIPLE_RESPONSIBILITIES", Description="A class or method has multiple responsibilities." } },
            { TechDebtCode.DEBT_NON_COMPLIANCE_WITH_STANDARDS, new TechDebtType { Title = "NON_COMPLIANCE_WITH_STANDARDS", Description="Non compliance with team or company development standards." } },
            { TechDebtCode.DEBT_NON_EXCEPTION, new TechDebtType { Title = "NON_EXCEPTION", Description="Exception mechanism usage for non exceptional cases." } },
            { TechDebtCode.DEBT_ODDBALL_SOLUTION, new TechDebtType { Title = "ODDBALL_SOLUTION", Description="The problem is solved one way throughout the system and the same problem is solved another way in the same system. One of the solutions is the oddball or the inconsistent solution and has to be eliminated." } },
            { TechDebtCode.DEBT_OTHER, new TechDebtType { Title = "OTHER", Description="Catch-all {@link SmellType} when you want to report an issue but can't find a corresponding {@link SmellType}." } },
            { TechDebtCode.DEBT_OVERCOMPLICATED_ALGORITHM, new TechDebtType { Title = "OVERCOMPLICATED_ALGORITHM", Description="There is a way to simplify this algorithm." } },
            { TechDebtCode.DEBT_PRIMITIVES_OBSESSION, new TechDebtType { Title = "PRIMITIVES_OBSESSION", Description="Primitives, which include integers, Strings, doubles, arrays and other low-level language elements, are generic because many people use them. Classes, on the other hand, may be as specific as you need them to be, since you create them for specific purposes. In many cases, classes provide a simpler and more natural way to model things than primitives. In addition, once you create a class, you’ll often discover how other code in a system belongs in that class. Fowler and Beck explain how primitive obsession manifests itself when code relies too much on primitives. This typically occurs when you haven’t yet seen how a higher-level abstraction can clarify or simplify your code." } },
            { TechDebtCode.DEBT_REFUSED_BEQUEST, new TechDebtType { Title = "REFUSED_BEQUEST", Description="The class extends another classes' methods but does not use them. Why extending the class then ?" } },
            { TechDebtCode.DEBT_REINVENTED_WHEEL, new TechDebtType { Title = "REINVENTED_WHEEL", Description="A library does the same job, probably better." } },
            { TechDebtCode.DEBT_SOLUTION_SPRAWL, new TechDebtType { Title = "SOLUTION_SPRAWL", Description="It takes too many classes to do anything useful, you might have solution sprawl. Consider simplifying and consolidating your design." } },
            { TechDebtCode.DEBT_SPECULATIVE_GENERALITY, new TechDebtType { Title = "SPECULATIVE_GENERALITY", Description="The code is written thinking about tomorrow's problems. Write code to solve today's problems, and worry about tomorrow's problems when they actually materialize. Everyone loses in the 'what if...' school of design." } },
            { TechDebtCode.DEBT_UNCOMMUNICATIVE_NAME, new TechDebtType { Title = "UNCOMMUNICATIVE_NAME", Description="The class, interface, method, field, variable or parameter name should be renamed in order to make it describe what it does or what it represents." } },
            { TechDebtCode.DEBT_USELESS_TEST, new TechDebtType { Title = "USELESS_TEST", Description="The test is useless (it tests nothing.)" } },
            { TechDebtCode.DEBT_WRONG_LANGUAGE, new TechDebtType { Title = "WRONG_LANGUAGE", Description="Wrong language (french, english, german...) is being used." } },
            { TechDebtCode.DEBT_WRONG_LOGIC, new TechDebtType { Title = "WRONG_LOGIC", Description="Wrong (business) logic is being used." } }
        };
    }
    public enum TechDebtCode { DEBT_ABBREVIATIONS_USAGE, DEBT_ANTI_PATTERN, DEBT_BAD_DESIGN, DEBT_BAD_FRAMEWORK_USAGE, DEBT_BAD_LOGGING, DEBT_HOW_COMMENT, DEBT_INDECENT_EXPOSURE, DEBT_MEANINGLESS_COMMENT, DEBT_MIDDLE_MAN, DEBT_MISSING_IMPLEMENTATION, DEBT_MISSING_TEST, DEBT_MISSING_DOCUMENTATION, DEBT_MULTIPLE_RESPONSIBILITIES, DEBT_NON_COMPLIANCE_WITH_STANDARDS, DEBT_NON_EXCEPTION, DEBT_ODDBALL_SOLUTION, DEBT_OTHER, DEBT_OVERCOMPLICATED_ALGORITHM, DEBT_PRIMITIVES_OBSESSION, DEBT_REFUSED_BEQUEST, DEBT_REINVENTED_WHEEL, DEBT_SOLUTION_SPRAWL, DEBT_SPECULATIVE_GENERALITY, DEBT_UNCOMMUNICATIVE_NAME, DEBT_USELESS_TEST, DEBT_WRONG_LANGUAGE, DEBT_WRONG_LOGIC };
}