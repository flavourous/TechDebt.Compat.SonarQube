using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechDebtTypes;
using System.Threading.Tasks;

namespace TechDebtTypes
{
    public class IssueAttribute : Attribute
    {
        public IssueAttribute(String reason, double effort) { }
    }
    public class RiskAttribute : Attribute
    {
        public RiskAttribute(String reason, double effort) { }
    }
    public class SmellAttribute : Attribute
    {
        public SmellAttribute(Smell type, String reason, double effort) { }
    }
    public class SmellType
    {
        private SmellType() { }
        public String Title { get; private set; }
        public String Description { get; private set; }

        public static readonly IReadOnlyDictionary<Smell, SmellType> Descriptors = new Dictionary<Smell, SmellType>
        {
            { Smell.DEBT_ABBREVIATIONS_USAGE, new SmellType { Title = "ABBREVIATIONS_USAGE", Description="Confusing abbreviations are being used instead of explicit names." } },
            { Smell.DEBT_ANTI_PATTERN, new SmellType { Title = "ANTI_PATTERN", Description="An anti-pattern has been used." } },
            { Smell.DEBT_BAD_DESIGN, new SmellType { Title = "BAD_DESIGN", Description="The design is really bad and should be improved." } },
            { Smell.DEBT_BAD_FRAMEWORK_USAGE, new SmellType { Title = "BAD_FRAMEWORK_USAGE", Description="A framework is not used the way it should." } },
            { Smell.DEBT_BAD_LOGGING, new SmellType { Title = "BAD_LOGGING", Description="The logging message, level, is inappropriate or the log is redundant." } },
            { Smell.DEBT_HOW_COMMENT, new SmellType { Title = "HOW_COMMENT", Description="The comment or documentation text focuses on the 'how' instead of the why" } },
            { Smell.DEBT_INDECENT_EXPOSURE, new SmellType { Title = "INDECENT_EXPOSURE", Description="The class unnecessarily exposes its internals. Aggressively refactor classes to minimize its public surface. You should have a compelling reason for every item you make public. If you don't, hide it." } },
            { Smell.DEBT_MEANINGLESS_COMMENT, new SmellType { Title = "MEANINGLESS_COMMENT", Description="The comment or javadoc should be reviewed: it makes no sense or does not seem to be related to the code !" } },
            { Smell.DEBT_MIDDLE_MAN, new SmellType { Title = "MIDDLE_MAN", Description="The class delegates all its work, is it really needed ? Cut out the middle man unless you really need a wrapper." } },
            { Smell.DEBT_MISSING_IMPLEMENTATION, new SmellType { Title = "MISSING_IMPLEMENTATION", Description="A method's implementation is missing." } },
            { Smell.DEBT_MISSING_TEST, new SmellType { Title = "MISSING_TEST", Description="An important test is missing." } },
            { Smell.DEBT_MISSING_DOCUMENTATION, new SmellType { Title = "MISSING_DOCUMENTATION", Description="An important documentation is missing." } },
            { Smell.DEBT_MULTIPLE_RESPONSIBILITIES, new SmellType { Title = "MULTIPLE_RESPONSIBILITIES", Description="A class or method has multiple responsibilities." } },
            { Smell.DEBT_NON_COMPLIANCE_WITH_STANDARDS, new SmellType { Title = "NON_COMPLIANCE_WITH_STANDARDS", Description="Non compliance with team or company development standards." } },
            { Smell.DEBT_NON_EXCEPTION, new SmellType { Title = "NON_EXCEPTION", Description="Exception mechanism usage for non exceptional cases." } },
            { Smell.DEBT_ODDBALL_SOLUTION, new SmellType { Title = "ODDBALL_SOLUTION", Description="The problem is solved one way throughout the system and the same problem is solved another way in the same system. One of the solutions is the oddball or the inconsistent solution and has to be eliminated." } },
            { Smell.DEBT_OTHER, new SmellType { Title = "OTHER", Description="Catch-all {@link SmellType} when you want to report an issue but can't find a corresponding {@link SmellType}." } },
            { Smell.DEBT_OVERCOMPLICATED_ALGORITHM, new SmellType { Title = "OVERCOMPLICATED_ALGORITHM", Description="There is a way to simplify this algorithm." } },
            { Smell.DEBT_PRIMITIVES_OBSESSION, new SmellType { Title = "PRIMITIVES_OBSESSION", Description="Primitives, which include integers, Strings, doubles, arrays and other low-level language elements, are generic because many people use them. Classes, on the other hand, may be as specific as you need them to be, since you create them for specific purposes. In many cases, classes provide a simpler and more natural way to model things than primitives. In addition, once you create a class, you’ll often discover how other code in a system belongs in that class. Fowler and Beck explain how primitive obsession manifests itself when code relies too much on primitives. This typically occurs when you haven’t yet seen how a higher-level abstraction can clarify or simplify your code." } },
            { Smell.DEBT_REFUSED_BEQUEST, new SmellType { Title = "REFUSED_BEQUEST", Description="The class extends another classes' methods but does not use them. Why extending the class then ?" } },
            { Smell.DEBT_REINVENTED_WHEEL, new SmellType { Title = "REINVENTED_WHEEL", Description="A library does the same job, probably better." } },
            { Smell.DEBT_SOLUTION_SPRAWL, new SmellType { Title = "SOLUTION_SPRAWL", Description="It takes too many classes to do anything useful, you might have solution sprawl. Consider simplifying and consolidating your design." } },
            { Smell.DEBT_SPECULATIVE_GENERALITY, new SmellType { Title = "SPECULATIVE_GENERALITY", Description="The code is written thinking about tomorrow's problems. Write code to solve today's problems, and worry about tomorrow's problems when they actually materialize. Everyone loses in the 'what if...' school of design." } },
            { Smell.DEBT_UNCOMMUNICATIVE_NAME, new SmellType { Title = "UNCOMMUNICATIVE_NAME", Description="The class, interface, method, field, variable or parameter name should be renamed in order to make it describe what it does or what it represents." } },
            { Smell.DEBT_USELESS_TEST, new SmellType { Title = "USELESS_TEST", Description="The test is useless (it tests nothing.)" } },
            { Smell.DEBT_WRONG_LANGUAGE, new SmellType { Title = "WRONG_LANGUAGE", Description="Wrong language (french, english, german...) is being used." } },
            { Smell.DEBT_WRONG_LOGIC, new SmellType { Title = "WRONG_LOGIC", Description="Wrong (business) logic is being used." } }
        };
    }
    public enum Smell { DEBT_ABBREVIATIONS_USAGE, DEBT_ANTI_PATTERN, DEBT_BAD_DESIGN, DEBT_BAD_FRAMEWORK_USAGE, DEBT_BAD_LOGGING, DEBT_HOW_COMMENT, DEBT_INDECENT_EXPOSURE, DEBT_MEANINGLESS_COMMENT, DEBT_MIDDLE_MAN, DEBT_MISSING_IMPLEMENTATION, DEBT_MISSING_TEST, DEBT_MISSING_DOCUMENTATION, DEBT_MULTIPLE_RESPONSIBILITIES, DEBT_NON_COMPLIANCE_WITH_STANDARDS, DEBT_NON_EXCEPTION, DEBT_ODDBALL_SOLUTION, DEBT_OTHER, DEBT_OVERCOMPLICATED_ALGORITHM, DEBT_PRIMITIVES_OBSESSION, DEBT_REFUSED_BEQUEST, DEBT_REINVENTED_WHEEL, DEBT_SOLUTION_SPRAWL, DEBT_SPECULATIVE_GENERALITY, DEBT_UNCOMMUNICATIVE_NAME, DEBT_USELESS_TEST, DEBT_WRONG_LANGUAGE, DEBT_WRONG_LOGIC };
}