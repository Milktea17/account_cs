using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class GiftCardAccount : BankAccount
    {
        //기본클래스 생성자에 인수를 전달할 생성자
        //base() : 기본 클래스 생성자에 대한 호출을 나타냄

        private decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
            => _monthlyDeposit = monthlyDeposit;


    }
}
