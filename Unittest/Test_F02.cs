using F02;
using F02.DTO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

namespace Unittest
{
    [TestClass]
    public class Test_F02
    {
        [TestMethod]
        [TestCategory("Uppgift 4: Switch")]
        [DataRow(18)]
        [DataRow(19)]
        [DataRow(20)]
        [DataRow(21)]
        public void CheckIfSwitchWillTurnOn_ShouldReturnMessage(int temp)
        {
            var testSwitch = new SwitchControl();
            testSwitch.Temperature = temp;
            Assert.AreEqual("Temperature = accepted range", testSwitch.StatusOnSwitch());
        }

        [TestMethod]
        [TestCategory("Uppgift 4: Switch")]
        [DataRow(17)]
        public void CheckIfSwitchWillTurnOff_ShouldReturnON(int temp)
        {
            var testSwitch = new SwitchControl();
            testSwitch.Temperature = temp;
            Assert.AreEqual("ON", testSwitch.StatusOnSwitch());
        }

        [TestMethod]
        [TestCategory("Uppgift 4: Switch")]
        [DataRow(22)]
        public void CheckIfSwitchWillTurnOff_ShouldReturnOFF(int temp)
        {
            var testSwitch = new SwitchControl();
            testSwitch.Temperature = temp;
            Assert.AreEqual("OFF", testSwitch.StatusOnSwitch());
        }

        [TestMethod]
        [TestCategory("Uppgift 5: CheckScore")]
        [DataRow(24)]
        [DataRow(25)]
        [DataRow(39)]
        [DataRow(40)]
        public void CheckIfStudentPass_ShouldReturnTrue(int score)
        {
            var testScore = new CheckScore();
            bool result = testScore.DidStudentPass(score);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [TestCategory("Uppgift 5: CheckScore")]
        [DataRow(23)]
        [DataRow(41)]
        public void CheckIfStudentPass_ShouldReturnFalse(int score)
        {
            var testScore = new CheckScore();
            bool result = testScore.DidStudentPass(score);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("Uppgift 6: Textfield Accept only Numeric (18-25)")]
        [DataRow("17", false)]
        [DataRow("18", true)]
        [DataRow("19", true)]
        [DataRow("25", true)]
        [DataRow("26", false)]
        [DataRow(null, false)]
        [DataRow("0", false)]
        [DataRow("!!!", false)]
        [DataRow("", false)]
        [DataRow("test", false)]
        [DataRow("564.", false)]
        public void CheckWhatTaxBracket_ShouldMeetExpectedValue(string input, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.TextBoxOnlyAcceptNumericValues(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 7: SalaryTax (Normal Test)")]
        [DataRow(0,0)]
        [DataRow(4000,0)]
        [DataRow(4001, 10)]
        [DataRow(5500, 10)]
        [DataRow(5501, 22)]
        [DataRow(33500, 22)]
        [DataRow(33501, 40)]
        [DataRow(4000000, 40)]
        [DataRow(-355555, 0)]
        public void CheckWhatTaxBracket_test1_ShouldMeetExpectedValue(int salary,int expected)
        {
            var testTax = new InputField();
            int result = testTax.WhatTaxBracketBasedOnIncome(salary);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 7: SalaryTax (Strange numbers and result)")]
        [DataRow(0, 10)]
        [DataRow(null,30)]
        [DataRow(33500, 40)]
        public void CheckWhatTaxBracket_test2_ShouldNOTMeetExpectedValue(int salary, int expected)
        {
            var testTax = new InputField();
            int result = testTax.WhatTaxBracketBasedOnIncome(salary);
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 7: Pay how much tax? (INT) (Normal test)")]
        [DataRow(3000,0)]
        [DataRow(5000,100)]
        [DataRow(6000,260)]
        [DataRow(50000,12910)]
        public void CheckAmountOfTax_ShouldMeetExpectedValue(int salary, int expected)
        {
            var testTax = new InputField();
            int result = testTax.CheckAmountOfTax(salary);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [TestCategory("Uppgift 8: NumericField")]
        [DataRow(9, false)]
        [DataRow(10, true)]
        [DataRow(11, true)]
        [DataRow(20, true)]
        [DataRow(21, true)]
        [DataRow(22, false)]
        [DataRow(23, false)]

        public void CheckIfNumberIsValid_ShouldMeetExpectedValue(int number, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.IsThisNumberAcceptedInField(number);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 9a: ZipCode NumericField [5 numeric]")]
        [DataRow(9, false)]
        [DataRow(9999, false)]
        [DataRow(10000, true)]
        [DataRow(10001, true)]
        [DataRow(99998, true)]
        [DataRow(99999, true)]
        [DataRow(100000, false)]

        public void CheckIfZipCodeisValid_ShouldMeetExpectedValue(int zipcode, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.IsZipCodeAccepted(zipcode);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 9b: State abbreviations [2 chars]")]
        [DataRow("TX", true)]
        [DataRow("GB", true)]
        [DataRow("TRF",false)]
        [DataRow("456",false)]
        [DataRow("45",false)]
        [DataRow("GB.",false)]
        
        public void CheckIfStateIsValid_ShouldMeetExpectedValue(string state, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.IsStateAccepted(state);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 9c: Lastname [1-15 chars]")]
        [DataRow("", false)]
        [DataRow("a", true)]
        [DataRow("dwehid3wi", true)]
        [DataRow("hhhhhhhhhhhhhhh", true)]
        [DataRow("hhhhhhhhhhhhhhhh", false)]
        [DataRow("8jk,.@@",true)]
        [DataRow(null,false)]

        public void CheckIfLastnameIsAccepted_ShouldMeetExpectedValue(string lastname, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.IsLastnameValid(lastname);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 9d: ZIP User ID [8 chars, 2>= non letters]")]
        [DataRow("TestNamn",false)]
        [DataRow("TestNamnHej",false)]
        [DataRow("111111GH",true)]
        [DataRow("Mark1..N",true)]
        [DataRow("Markus90",true)]
        [DataRow(null,false)]
        [DataRow("",false)]
        [DataRow("hej56",false)]
        [DataRow("        ",true)]
        [DataRow("Mar\th9dd",true)] //non printeble char tab

        public void CheckIfUserIDIsValid_ShouldMeetExpectedValue(string userid, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.IsUserIDValid(userid);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 9e: Student ID [8 chars, First 2 Campus abb [2 char], unique 6 digit number]")]
        [DataRow("AN123456",true)]
        [DataRow("ANE12345", false)]
        [DataRow("AN1234567",false)]
        [DataRow("12345678",false)]
        [DataRow("WN345134",true)]
        [DataRow("LCTGYHGR",false)]
        public void CheckIfStudentIDIsValid_ShouldMeetExpectedValue(string studentId, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.IsStudentIDValid(studentId);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 10: Sending in a ValidBankForm [Acc nr 10 digits")]
        [DynamicData(nameof(GetValidBankForms),DynamicDataSourceType.Method)] //Alla test klumpas ihop till ett
        public void CheckIfBankFormIsValid_ShouldMeetExpectedValue(BankForm_dto form, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.IsBankFormValid(form);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Uppgift 10: Sending in a InValidBankForm [Acc nr 10 digits")]
        [DynamicData(nameof(GetInValidBankForms), DynamicDataSourceType.Method)] //Alla test klumpas ihop till ett
        public void CheckIfBankFormIsInValid_ShouldMeetExpectedValue(BankForm_dto form, bool expected)
        {
            var testInput = new InputField();
            bool result = testInput.IsBankFormValid(form);
            Assert.AreEqual(expected, result);
        }

        private static IEnumerable<object[]> GetValidBankForms()
        {
            List<object[]> bankForms = new List<object[]>();
            bankForms.Add(new object[] { new BankForm_dto { 
                Product = "Loan equity loan", 
                CheckingExists = false, 
                SavingExists = false, 
                CheckingAccountNumber= "", 
                SavingAccountNumber = "" }, 
                true }) ;
            bankForms.Add(new object[] { new BankForm_dto { 
                Product = "Loan equity loan",
                CheckingExists = true,
                CheckingAccountNumber = "1234567891",
                SavingExists = false,
                SavingAccountNumber = ""}, 
                true });
            bankForms.Add(new object[] { new BankForm_dto {
                Product = "Reverse mortage",
                CheckingExists = false,
                CheckingAccountNumber = "",
                SavingExists = true,
                SavingAccountNumber = "1234567891"},
                true });
            return bankForms;
        }

        private static IEnumerable<object[]> GetInValidBankForms()
        {
            List<object[]> bankForms = new List<object[]>();
            bankForms.Add(new object[] { new BankForm_dto {
                Product = "Loan equity",
                CheckingExists = false,
                SavingExists = false,
                CheckingAccountNumber= "",
                SavingAccountNumber = "" },
                false });
            bankForms.Add(new object[] { new BankForm_dto {
                Product = "Loan equity loan",
                CheckingExists = true,
                CheckingAccountNumber = "1234567891",
                SavingExists = true,
                SavingAccountNumber = ""},
                false });
            bankForms.Add(new object[] { new BankForm_dto {
                Product = "Loan equity loan",
                CheckingExists = true,
                CheckingAccountNumber = "",
                SavingExists = true,
                SavingAccountNumber = "1234567891"},
                false });
            return bankForms;
        }

    }
}