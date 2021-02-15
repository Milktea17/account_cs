using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*--------------------------------------
 월말 작업
 - 매월 한 번 말일에 지정된 금액으로 계좌를 다시 채울 수 있습니다.
 --------------------------------------*/

namespace classes
{
    public class GiftCardAccount : BankAccount
    {
        //기본클래스 생성자에 인수를 전달할 생성자
        //base() : 기본 클래스 생성자에 대한 호출을 나타냄
        /*
        public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }
        */
        private decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
        //=> _monthlyDeposit = monthlyDeposit;
        { _monthlyDeposit = monthlyDeposit; }

        public override void PerformMonthEndTransaction()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }

    }
}
