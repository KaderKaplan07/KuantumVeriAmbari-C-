using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuantumVeriAmbari
{
    public class KuantumCokusuException : Exception
    {
        public KuantumCokusuException(string patlayanNesneID)
            : base($"KRİTİK HATA! {patlayanNesneID} kimlikli nesne çöktü! Kuantum dengesi bozuldu.")
        {
        }
    }
}
