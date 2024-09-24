using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLogic.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsCorrectResult()
        {
            var result = _calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Divide_DivideByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -1, -2)]
        [InlineData(0, 0, 0)]
        public void Add_MultipleCases_ReturnsCorrectResult(int a, int b, int expected)
        {
            var result = _calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void Add_ClassData_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetCalculatorData()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 5, 5, 10 };
            yield return new object[] { -1, -1, -2 };
        }

        [Theory]
        [MemberData(nameof(GetCalculatorData))]
        public void Add_MemberData_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetDataFromJson()
        {
            string a = AppContext.BaseDirectory;
            // Đọc dữ liệu từ file JSON
            var jsonData = File.ReadAllText("..\\Desktop\\CSharpLearning\\BusinessLogic\\BusinessLogic.Tests\\testdata.json");

            // Deserialize JSON thành List<TestCaseData>
            var testCases = JsonConvert.DeserializeObject<List<TestCaseData>>(jsonData);

            // Trả về dữ liệu dưới dạng IEnumerable<object[]>
            foreach (var testCase in testCases)
            {
                yield return new object[] { testCase.A, testCase.B, testCase.Expected };
            }
        }

        [Theory]
        [MemberData(nameof(GetDataFromJson))]
        public void Add_UsingJsonData_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        public class TestCaseData
        {
            public int A { get; set; }
            public int B { get; set; }
            public int Expected { get; set; }
        }

    }
}
