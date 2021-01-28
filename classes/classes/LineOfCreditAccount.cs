using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class LineOfCreditAccount : BankAccount
    {
        //기본클래스 생성자에 인수를 전달할 생성자
        //base() : 기본 클래스 생성자에 대한 호출을 나타냄
        LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
        { }

        public override void PerformMonthEndTransaction()
        {
            var interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }

    }
}
