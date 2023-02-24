using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;
namespace Samples.InstrumentedTests.Iast.Vulnerabilities.StringPropagation;
public class StringFormatTests : InstrumentationTestsBase
{
    protected string taintedValue = "tainted";
    protected string taintedValue2 = "TAINTED2";
    protected string TaintedString = "TaintedString";
    protected string UntaintedString = "UntaintedString";
    protected string OtherTaintedString = "OtherTaintedString";
    protected string OtherUntaintedString = "OtherUntaintedString";
    protected object UntaintedObject = "UntaintedObject";
    protected object TaintedObject = "TaintedObject";
    protected object OtherTaintedObject = "OtherTaintedObject";
    protected object OtherUntaintedObject = "OtherUntaintedObject";
    protected string formatTaintedValue = "format{0}{1}";
    public StringFormatTests()
    {
        AddTainted(taintedValue);
        AddTainted(taintedValue2);
        AddTainted(TaintedObject);
        AddTainted(OtherTaintedObject);
        AddTainted(TaintedString);
        AddTainted(OtherTaintedString);
        AddTainted(formatTaintedValue);
    }
    //Basic cases
    
    [Fact]
    public void String_Format()
    {
        string testString1 = " Test String Value 1 ";
        AddTainted(testString1);
        string result1 = String.Format("--Format string {0} - {0} - {1} -", testString1, "Decoy");
        string result2 = String.Format("--Format string * {0} * {0} * {1} *", result1, "Decoy");
        Assert.Equal("--Format string :+- Test String Value 1 -+: - :+- Test String Value 1 -+: - Decoy -", FormatTainted(result1));
        Assert.Equal("--Format string * --Format string :+- Test String Value 1 -+: - :+- Test String Value 1 -+: - Decoy - * --Format string :+- Test String Value 1 -+: - :+- Test String Value 1 -+: - Decoy - * Decoy *", FormatTainted(result2));
    }

    [Fact]
    public void String_Format_With_Tainted()
    {
        Assert.Equal("Literal equals to :+-TaintedString-+:", FormatTainted(String.Format("Literal equals to {0}", TaintedString)));
    }
    
    [Fact]
    public void String_Format_With_Untainted()
    {
        string str = "{0} and Literal equals to {1}";
        Assert.Equal(":+-TaintedString-+: and Literal equals to UntaintedString", FormatTainted(String.Format(str, TaintedString, UntaintedString)));
    }
    
    [Fact]
    public void String_Format_With_Two_Tainted()
    {
        string str = "{0} and Literal equals to {1}";
        Assert.Equal(":+-TaintedString-+: and Literal equals to :+-OtherTaintedString-+:", FormatTainted(String.Format(str, TaintedString, OtherTaintedString)));
    }
    
    [Fact]
    public void String_Format_With_Both()
    {
        string str = "Literal with tainted {0} and untainted {1} and tainted {2}";
        Assert.Equal("Literal with tainted :+-TaintedString-+: and untainted UntaintedString and tainted :+-OtherTaintedString-+:", FormatTainted(String.Format(str, TaintedString, UntaintedString, OtherTaintedString)));
    }
    
    [Fact]
    public void String_Format_With_Both_Joined()
    {
        string str = "Literal with tainted/untainted {0}{1} and tainted {2}";
        Assert.Equal("Literal with tainted/untainted :+-TaintedString-+:UntaintedString and tainted :+-OtherTaintedString-+:", FormatTainted(String.Format(str, TaintedString, UntaintedString, OtherTaintedString)));
    }
    
    [Fact]
    public void String_Format_Four_Params()
    {
        string str = "Literal with tainted {0} and untainted {1} and tainted {2} and another untainted {3}";
        Assert.Equal("Literal with tainted :+-TaintedString-+: and untainted UntaintedString and tainted :+-OtherTaintedString-+: and another untainted OtherUntaintedString", FormatTainted(String.Format(str, TaintedString, UntaintedString, OtherTaintedString, OtherUntaintedString)));
    }
    
    [Fact]
    public void String_Format_Five_Params()
    {
        string str = "Literal with tainteds {0}{1} and untainted {2} and tainted {3} and another untainted {4}";
        Assert.Equal("Literal with tainteds :+-TaintedString-+::+-OtherTaintedString-+: and untainted UntaintedString and tainted :+-OtherTaintedString-+: and another untainted OtherUntaintedString", FormatTainted(String.Format(str, TaintedString, OtherTaintedString, UntaintedString, OtherTaintedString, OtherUntaintedString)));
    }
    
    [Fact]
    public void String_Format_Provider_With_Both()
    {
        var customerName = AddTaintedString("TaintedCustomerName");
        Customer customer = new Customer(customerName, 999654);
        var result1 = String.Format(new CustomerNumberFormatter(), "Tainted literal equals to {0} and number {1}", customer.Name, customer.CustomerNumber);
        Assert.Equal("Tainted literal equals to TaintedCustomerName and number 0000-999-654", result1);
        Assert.Equal("Tainted literal equals to :+-TaintedCustomerName-+: and number 0000-999-654", result1);
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormat_ObjectIsTainted()
    {
        var taintedObject = "3";
        var longText = "\r\n                        ^[ ]{{0,{0}}}\\[(.+)\\]:  # id = $1\r\n                          [ ]*\r\n                          \\n?                   # maybe *one* newline\r\n                          [ ]*\r\n                        <?(\\S+?)>?              # url = $2\r\n                          [ ]*\r\n                          \\n?                   # maybe one newline\r\n                          [ ]*\r\n                        (?:\r\n                            (?<=\\s)             # lookbehind for whitespace\r\n                            [\"(]\r\n                            (.+?)               # title = $3\r\n                            [\")]\r\n                            [ ]*\r\n                        )?                      # title is optional\r\n                        (?:\\n+|\\Z)";
        AddTainted(taintedObject);
        var str1 = String.Format(longText, taintedObject);
        // Utils.CheckTaintedFragments(str1, taintedObject.ToString());
        FormatTainted(str1).Should().Be("\r\n                        ^[ ]{{0,:+-3-+:}}\\[(.+)\\]:  # id = $1\r\n                          [ ]*\r\n                          \\n?                   # maybe *one* newline\r\n                          [ ]*\r\n                        <?(\\S+?)>?              # url = $2\r\n                          [ ]*\r\n                          \\n?                   # maybe one newline\r\n                          [ ]*\r\n                        (?:\r\n                            (?<=\\s)             # lookbehind for whitespace\r\n                            [\"(]\r\n                            (.+?)               # title = $3\r\n                            [\")]\r\n                            [ ]*\r\n                        )?                      # title is optional\r\n                        (?:\\n+|\\Z)");
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormatWithSpecificformat_FramentsAreTainted()
    {
        string testString1 = "3";
        AddTainted(testString1);
        var longText = "{{0,{0}}}";
        string result1 = String.Format(longText, testString1);
        Assert.Equal("{0,3}", result1);
        Assert.Equal("{0,:+-3-+:}", FormatTainted(result1));
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormatWithdoubleBrackets_FramentsAreNotTainted()
    {
        string testString1 = "3";
        AddTainted(testString1);
        var longText = "{{0}}";
#pragma warning disable S3457 // Composite format strings should be used correctly
        string result1 = String.Format(longText, testString1);
#pragma warning restore S3457 // Composite format strings should be used correctly
        Assert.Equal("{0}", result1);
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormatWithdoubleBrackets_Only1FramentIsTainted()
    {
        string testString1 = "3";
        string testString2 = "5";
        AddTainted(testString1);
        AddTainted(testString2);
        var longText = "{{0}}{1}";
#pragma warning disable S3457 // Composite format strings should be used correctly
        string result1 = String.Format(longText, testString1, testString2);
#pragma warning restore S3457 // Composite format strings should be used correctly
        Assert.Equal("{0}5", result1);
        FormatTainted(result1).Should().Be("{0}:+-5-+:");
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormatWithTwoArguments_FramentsAreTainted()
    {
        string testString1 = "3";
        string testString2 = "4";
        AddTainted(testString1);
        AddTainted(testString2);
        string result1 = String.Format("{0} {1}", testString1, testString2);
        Assert.Equal("3 4", result1);
        FormatTainted(result1).Should().Be(":+-3-+::+-4-+:");
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormatWithTwoArgumentsWithDifferentLenghts_FramentsAreTainted()
    {
        string testString1 = "3333";
        string testString2 = "44444";
        AddTainted(testString1);
        AddTainted(testString2);
        string result1 = String.Format("{1} {0}", testString1, testString2);
        Assert.Equal("44444 3333", result1);
        Assert.Equal(":+-44444-+: :+-3333-+:", FormatTainted(result1));
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormatWithCommaAndColon_FramentsAreTainted()
    {
        string testString1 = "aaa";
        AddTainted(testString1);
        string result1 = String.Format("{0, 2 :d}", testString1);
        Assert.Equal("aaa", result1);
        Assert.Equal(":+-aaa-+:", FormatTainted(result1));
    }
    
    [Fact]
    // [ExpectedException(typeof(FormatException))]
    public void GivenAString_WhenCallingFormatWithWrongArgumentFormat_ExceptionIsThrown()
    {
        string testString1 = "3";
        AddTainted(testString1);
        string result1 = String.Format("{{eee} {0}}", testString1);
        Assert.Equal("{eee} 3", result1);
        Assert.Equal("{eee} :+-3-+:", FormatTainted(result1));
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormatAlternatingDummyCharachters_FramentsAreTainted()
    {
        string testString1 = "3454545";
        AddTainted(testString1);
        string result1 = String.Format("dd {0} gfgd gd {0} gfgdf  {0}fg fg g", testString1);
        Assert.Equal("dd 3454545 gfgd gd 3454545 gfgdf  3454545fg fg g", result1);
        Assert.Equal("dd :+-3454545-+: gfgd gd :+-3454545-+: gfgdf  :+-3454545-+: fg g", FormatTainted(result1));
    }
    
    [Fact]
    // [ExpectedException(typeof(FormatException))]
    public void GivenAString_WhenCallingFormatWithInvalidArgumentSpaceFormat_ExceptionIsThrown()
    {
        string testString1 = "3";
        AddTainted(testString1);
#pragma warning disable S2275
        string result1 = String.Format("dd {0} { 0}", testString1);
#pragma warning restore S2275
        Assert.Equal("dd 3 { 0}", result1);
        Assert.Equal("dd :+-3-+: { 0}", FormatTainted(result1));
    }
    
    [Fact]
    public void GivenAString_WhenCallingFormatWithTheArgumentInTheString_FramentsAreTainted()
    {
        string testString1 = "3";
        AddTainted(testString1);
        string result1 = String.Format("dd 3 {0} 3", testString1);
        Assert.Equal("dd 3 3 3", result1);
        Assert.Equal("dd 3 :+-3-+: 3", FormatTainted(result1));
    }
    [Fact]
    // [ExpectedException(typeof(FormatException))]
    public void GivenAString_WhenCallingFormatWithMissingArguments_ExceptionIsThrown()
    {
        string testString1 = "345";
        AddTainted(testString1);
#pragma warning disable S2275 // Composite format strings should not lead to unexpected behavior at runtime
        _ = String.Format("dd {0} {2} {2}", testString1);
#pragma warning restore S2275 // Composite format strings should not lead to unexpected behavior at runtime
    }
    
    [Fact]
    // [ExpectedException(typeof(FormatException))]
    public void GivenAString_WhenCallingFormatWithNumberFormatting_FramentsAreTainted()
    {
        string testString1 = "burgos";
        var pricePerOunce = 20.4m;
        AddTainted(testString1);
#pragma warning disable S2275 // Composite format strings should not lead to unexpected behavior at runtime
        string result1 = String.Format("The current price is {0:C2} per ounce in {1]}.", pricePerOunce, testString1);
#pragma warning restore S2275 // Composite format strings should not lead to unexpected behavior at runtime
    }

    
    [Fact]
    public void GivenAString_WhenCallingFormatWithDateAndNumbers_FramentsAreTainted()
    {
        string testString1 = "madrid";
        var date = DateTime.Now;
        var degrees = 20.4;
        AddTainted(testString1);
        string result1 = String.Format("At {0}, the temperature is {1}°C. in {2}", date, degrees, testString1);
        Assert.Equal("At " + date.ToString() + ", the temperature is " + degrees.ToString() + "°C. in madrid", result1);
        Assert.Equal("At " + date.ToString() + ", the temperature is " + degrees.ToString() + "°C. in :+-madrid-+:", FormatTainted(result1));
    }

    [Fact]
    public void GivenATaintedObject_WhenCallingFormatWithProvider_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck("test: :+-tainted-+:", String.Format(new FormatProviderForTest(), "test: {0}", new object[] { taintedValue }), () => String.Format(new FormatProviderForTest(), "test: {0}", new object[] { taintedValue }));
    }

    [Fact]
    public void GivenATaintedObject_WhenCallingFormatWithObjectArray_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck("test: :+-tainted-+:", String.Format("test: {0}", new object[] { taintedValue }), () => String.Format("test: {0}", new object[] { taintedValue }));
    }

    [Fact]
    public void GivenATaintedObject_WhenCallingFormatWithOneObject_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck("test: :+-tainted-+:", String.Format("test: {0}", taintedValue), () => String.Format("test: {0}", taintedValue));
    }

    [Fact]
    public void GivenATaintedObject_WhenCallingFormatWithTwoObjects_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck("test: :+-tainted-+: :+-TAINTED2-+:", String.Format("test: {0} {1}", taintedValue, taintedValue2), () => String.Format("test: {0} {1}", taintedValue, taintedValue2));
    }

    [Fact]
    public void GivenATaintedObject_WhenCallingFormatWithThreebjects_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck("test: :+-tainted-+: www :+-TAINTED2-+:", String.Format("test: {0} {1} {2}", taintedValue, "www", taintedValue2), () => String.Format("test: {0} {1} {2}", taintedValue, "www", taintedValue2));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormat_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck("format:+-tainted-+: :+-TAINTED2-+: :+-TAINTED2-+:",
            String.Format("format{0} {1} {2}", taintedValue, taintedValue2, taintedValue2),
            () => String.Format("format{0} {1} {2}", taintedValue, taintedValue2, taintedValue2));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithProvider_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck(":+-formattaintedTAINTED2-+:", String.Format(new FormatProviderForTest(), formatTaintedValue, new object[] { taintedValue, taintedValue2 }), () => String.Format(new FormatProviderForTest(), formatTaintedValue, new object[] { taintedValue, taintedValue2 }));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithProvider_ResultIsTainted2()
    {
        AssertTaintedFormatWithOriginalCallCheck(":+-formattaintedTAINTED2-+:",
            String.Format(new FormatProviderForTest(), formatTaintedValue, taintedValue, taintedValue2),
            () => String.Format(new FormatProviderForTest(), formatTaintedValue, taintedValue, taintedValue2));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithProvider_ResultIsTainted3()
    {
        AssertTaintedFormatWithOriginalCallCheck("format:+-tainted-+:",
            String.Format(new FormatProviderForTest(), "format{0}", taintedValue),
            () => String.Format(new FormatProviderForTest(), "format{0}", taintedValue));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithProvider_ResultIsTainted4()
    {
        AssertTaintedFormatWithOriginalCallCheck("format:+-tainted-+: :+-TAINTED2-+: :+-TAINTED2-+:",
            String.Format(new FormatProviderForTest(), "format{0} {1} {2}", taintedValue, taintedValue2, taintedValue2),
            () => String.Format(new FormatProviderForTest(), "format{0} {1} {2}", taintedValue, taintedValue2, taintedValue2));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithObjectArray_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck(":+-formattaintedTAINTED2-+:", String.Format(formatTaintedValue, new object[] { taintedValue, taintedValue2 }), () => String.Format(formatTaintedValue, new object[] { taintedValue, taintedValue2 }));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithObjectArray_ResultIsTainted2()
    {
        AssertTaintedFormatWithOriginalCallCheck(":+-formattaintednotTainted-+:", String.Format(formatTaintedValue, new object[] { taintedValue, "notTainted" }), () => String.Format(formatTaintedValue, new object[] { taintedValue, "notTainted" }));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithObjectArray_ResultIsTainted3()
    {
        AssertTaintedFormatWithOriginalCallCheck("abc:+-tainted-+:notTainted", String.Format("abc{0}{1}", new object[] { taintedValue, "notTainted" }), () => String.Format("abc{0}{1}", new object[] { taintedValue, "notTainted" }));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithTwoObjects_ResultIsTainted()
    {
        AssertTaintedFormatWithOriginalCallCheck(":+-formattaintedTAINTED2-+:", String.Format(formatTaintedValue, taintedValue, taintedValue2), () => String.Format(formatTaintedValue, taintedValue, taintedValue2));
    }

    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithNullFormatTwoObjects_ArgumentOutOfRangeException()
    {
        AssertTaintedFormatWithOriginalCallCheck(":+-tainted-+:", String.Format(null, taintedValue, taintedValue2), () => String.Format(null, taintedValue, taintedValue2));
    }
    
    [Fact]
    public void GivenATaintedFormatObject_WhenCallingFormatWithTwoObjectsOneIsNull_ArgumentOutOfRangeException()
    {
        AssertTaintedFormatWithOriginalCallCheck(":+-tainted-+:", String.Format(null, taintedValue, taintedValue2), () => String.Format(null, taintedValue, taintedValue2));
    }

    [Fact]
    //// [ExpectedException(typeof(System.FormatException))]
    public void GivenATaintedFormatObject_WhenCallingFormatWithOneObjectLess_FormatException()
    {
        String.Format(formatTaintedValue, taintedValue).Should().Throw<FormatException>();
    }

    [Fact]
        //// [ExpectedException(typeof(System.ArgumentNullException))]
    public void GivenATaintedFormatObject_WhenCallingFormatWithNullParams_FormatException()
    {
        AssertTaintedFormatWithOriginalCallCheck(String.Format(null, null, "r"), () => String.Format(null, null, "r"));
    }
    [Fact]
    public void GivenTaintedObject_StringFormatsAtBegining_ShouldNotCreateNewRanges()
    {
        var tainted = AddTainted("tainted");
        var to = GetTainted(tainted);
        var range = to.Ranges[0];
        var taintedFormat = string.Format("{0} rocks", tainted);
        var toFormat = GetTainted(taintedFormat);
        Assert.True(object.ReferenceEquals(range, toFormat.Ranges[0]));
    }
    [Fact]
    public void GivenTaintedObject_StringFormatAtEnding_ShouldCreateNewRanges()
    {
        var tainted = AddTainted("tainted");
        var to = GetTainted(tainted);
        var range = to.Ranges[0];
        var taintedFormat = string.Format("test {0}", tainted);
        var toFormat = GetTainted(taintedFormat);
        Assert.False(object.ReferenceEquals(range, toFormat.Ranges[0]));
    }
    public class FormatProviderForTest : IFormatProvider, ICustomFormatter
    {
        public string FormatTainted(string format, object arg, IFormatProvider formatProvider)
        {
            return (arg.ToString());
        }
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }

    public class CustomerNumberFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg is Int32)
            {
                string custNumber = ((int)arg).ToString("D10");
                return custNumber.Substring(0, 4) + "-" + custNumber.Substring(4, 3) + "-" + custNumber.Substring(7, 3);
            }
            else
            {
                return null;
            }
        }
    }

    public class Customer
    {
        private int custNumber;
        public Customer Parent { get; set; }
        public Customer Child { get; set; }
        public Customer() { }
        public Customer(string name, int number)
        {
            this.Name = name;
            this.custNumber = number;
        }
        public string Name { get; set; }
        public int CustomerNumber
        {
            get { return this.custNumber; }
            set { this.custNumber = value; }
        }
    }
}
