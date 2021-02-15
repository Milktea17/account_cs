using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*--------------------------------------
 월말 작업 //이건 7.1이상이어야 예제 동작해서 새로 작성예정
 - 음수의 잔고일 수 있지만 절대값은 대출 한도보다 클 수 없습니다.
 - 월말 잔고가 0이 아닌 경우 매달 이자 비용이 발생합니다.
 - 대출 한도를 초과하는 인출 때마다 수수료가 발생합니다. 
 --------------------------------------*/

namespace classes
{
    public class LineOfCreditAccount : BankAccount
    {
        //기본클래스 생성자에 인수를 전달할 생성자
        //base() : 기본 클래스 생성자에 대한 호출을 나타냄

        
        public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
        { }
    

        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
        }

        public override void PerformMonthEndTransaction()
        {
            if (Balance < 0)
            {
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }

    }
}
