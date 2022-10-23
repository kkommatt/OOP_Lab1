namespace MyExcel.Test
{
    [TestClass]
    public class UnitTest1
    {
        private static object Calculate(string expr)
        {
            var testCell = new MathCell(expr);
            testCell.EvaluateFormula();

            return testCell.Value;
        }
            [TestMethod]
        public void Evaluate_20plus20_40return()
        {
            // arrange
            const double x = 20;
            const double y = 20;
            string expr = $"={x} + {y}";
            const double expected = 40;

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Evaluate_10minus30_Neg20return()
        {
            // arrange
            const double x = 10;
            const double y = 30;
            string expr = $"={x} - {y}";
            const double expected = -20;

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Evaluate_5multiply20_100return()
        {
            // arrange
            const double x = 5;
            const double y = 20;
            string expr = $"={x} * {y}";
            const double expected = 100;

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Div_IntAndInt_DoubleReturn()
        {
            // arrange
            const int x = 6;
            const int y = 4;
            string expr = $"={x} / {y}";
            const double expected = 1.5;

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SetUnary_plus120_120return()
        {
            // arrange
            const double x = 120;
            string expr = $"=+{x}";
            const double expected = 120;

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SetUnary_minus10_Neg10return()
        {
            // arrange
            const double x = 120;
            string expr = $"=-{x}";
            const double expected = -120;

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Max_6and4_6Return()
        {
            // arrange
            const double x = 6;
            const double y = 4;

            string expr = $"=max({x}, {y})";
            const double expected = 6;

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Min_6and3_3Return()
        {
            // arrange
            const double x = 6;
            const double y = 3;

            string expr = $"=min({x}, {y})";
            const double expected = 3;

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Div_TwoDivSigns_InvalidOperationReturn()
        {
            // arrange
            const double x = 7.7778;
            const double y = 7.7777;

            string expr = $"={x} // {y}";
            const string expected = "InvalidOperation";

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Div_1and0_DivByZeroReturn()
        {
            // arrange
            const string expr = "=1/0";
            const string expected = "DivByZero";

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FalseMethod_InvalidOperationReturn()
        {
            // arrange
            const string expr = "=dsggsedbgdc(21)";
            const string expected = "InvalidOperation";

            // act
            var result = Calculate(expr);

            // assert
            Assert.AreEqual(expected, result);
        }

    }
}