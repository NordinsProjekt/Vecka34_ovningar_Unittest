using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using F02.DTO;

namespace F02
{
    public class InputField
    {
        public int WhatTaxBracketBasedOnIncome(int salary)
        {
            if (salary <= 4000) return 0;
            if (salary <= 5500) return 10;
            if (salary <= 33500) return 22;
            if (salary <= int.MaxValue) return 40;
            return -1;
        }

        public int CheckAmountOfTax(int salary)
        {
            var taxes = GetTaxList();
            int amount = 0;
            foreach (var t in taxes)
            {
                amount += CheckValuesForTax((int)t[0], (int)t[1], salary);
                salary -= (int)t[0];
                if (salary < 0) break;
            }
            return amount;
        }
        private int CheckValuesForTax(int amount, int tax, int salary)
        {
            int calculatedTax = 0;
            if (salary >= amount)
                calculatedTax += (amount / 100) * tax;
            else
            {
                calculatedTax += (salary / 100) * tax;
                return calculatedTax;
            }
            return calculatedTax;
        }
        private IEnumerable<object[]> GetTaxList()
        {
            var taxList = new List<object[]>();
            taxList.Add(new object[] { 4000, 0 });
            taxList.Add(new object[] { 1500, 10 });
            taxList.Add(new object[] { 28000, 22 });
            taxList.Add(new object[] { 99999999, 40 });
            return taxList;
        }
        public bool TextBoxOnlyAcceptNumericValues(string input)
        {
            if (int.TryParse(input, out int value))
                if (18 <= value && value <= 25) return true;
                else return false;
            else
                return false;
        }

        public bool IsThisNumberAcceptedInField(int number)
        {
            if (10 > number || 22 <= number) return false;
            return true;
        }

        public bool IsZipCodeAccepted(int zipcode) { return !(zipcode <= 9999 || zipcode >= 100000); }

        public bool IsStateAccepted(string state)
        {
            IEnumerable<string> states = StateAbb();
            if (state.Count() == 2 && states.Contains(state) ) return true;
            return false;
        }

        public bool IsLastnameValid(string lastname)
        {
            if (string.IsNullOrEmpty(lastname)) return false;
            if (lastname.Count() >= 1 && lastname.Count() <=15) return true;
            return false;
        }

        public bool IsUserIDValid(string userid)
        {
            if (string.IsNullOrEmpty (userid)) return false;
            int num = userid.Count(char.IsNumber);
            foreach (char c in userid)
                if (!char.IsLetterOrDigit(c)) num += 1;
            if (userid.Count() == 8 && num>= 2) return true; //Magi
            return false;
        }

        public bool IsStudentIDValid(string studentID)
        {
            var campus = CampusAbb();
            string cAbb = studentID.Substring(0, 2);
            string sID = studentID.Substring(2,6);
            if (campus.Contains(cAbb) && int.TryParse(sID, out int num) && sID.Count() == 6 && studentID.Count() == 8) return true;
            return false;
        }

        public bool IsBankFormValid(BankForm_dto bf)
        {
            var products = BankProducts();
            if (products.Contains(bf.Product))
            {
                if (IsCheckingValid(bf))
                {
                    if (IsSavingsValid(bf))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }
        private bool IsCheckingValid(BankForm_dto bf)
        {
            if (bf.CheckingExists == false)
                return true;
            if (bf.CheckingExists && int.TryParse(bf.CheckingAccountNumber, out int num) && bf.CheckingAccountNumber.Count() == 10)
                return true;
            return false;
        }

        private bool IsSavingsValid(BankForm_dto bf)
        {
            if (bf.SavingExists == false)
                return true;
            if (bf.SavingExists && int.TryParse(bf.SavingAccountNumber, out int num) && bf.SavingAccountNumber.Count() == 10)
                return true;
            return false;
        }
        private IEnumerable<string> BankProducts()
        {
            List<string> products = new List<string>() 
            {
                "Loan equity loan","Home equity line of credit","Reverse mortage"
            };
            return products;

        }
        private IEnumerable<string> StateAbb()
        {
            List<string> state = new List<string>() { "TX","GB","WA" };
            return state;
        }

        private IEnumerable<string> CampusAbb()
        {
            List<string> state = new List<string>() { "AN", "LC", "RW","SM","TA","WE","WN" };
            return state;
        }
    }
}
