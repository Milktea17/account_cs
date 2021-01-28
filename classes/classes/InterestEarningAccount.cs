using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class InterestEarningAccount : BankAccount
    {
        //기본클래스 생성자에 인수를 전달할 생성자
        //base() : 기본 클래스 생성자에 대한 호출을 나타냄
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        //기본 클래스 구현 재정의
        public override void PerformMonthEndTransaction()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }

        }
           
    }
}
