using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    //public 붙여줘야함! : 같은 패키지 내에선 public이지만 C#은 기본으로 private로 자동 지정
    public class BankAccount
    {
        //private니까 클래스 내의 코드로만 액세스 가능
        //static으로 객체내에서 공유됨
        private static int accountNumberSeed = 1234567890; //데이터멤버

        //property(3개) : get, set (getter, setter있음)
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance //속성영역
        {                       //이 안에 get, set 정의를 해준다
            get
            {
                decimal balance = 0;
                foreach (var item in allTransaction)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        //method(2개) : 단일함수를 수행하는 코드블록
        public BankAccount(string name, decimal initialBalance) //생성자
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

    //    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        private List<Transaction> allTransaction = new List<Transaction>(); //거래기록 저장

        public void MakeDeposit(decimal amount, DateTime date, string note) //예금
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransaction.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note) //인출
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransaction.Add(withdrawal);
        }

        //트랜젝션 기록에 대해 string을 생성
        public string GetAccountHistory()
        {
            //StringBuilder는 문자열을 조합할 때마다 새로운 변수를 생성할필요가 없다
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransaction)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        //virtual : 파생클래스를 구현할 수 있게
        public virtual void PerformMonthEndTransaction() { }
    }

   

}
