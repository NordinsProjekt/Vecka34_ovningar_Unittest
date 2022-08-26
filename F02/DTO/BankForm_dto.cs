using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F02.DTO
{
    public class BankForm_dto
    {
        public string Product { get; set; }
        public bool CheckingExists { get; set; }
        public bool SavingExists { get; set; }
        public string CheckingAccountNumber {get; set;}
        public string SavingAccountNumber {get; set;}
    }
}
