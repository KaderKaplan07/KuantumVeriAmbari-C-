using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuantumVeriAmbari
{
    public class VeriPaketi : KuantumNesnesi
    {
        public override void AnalizEt()
        {
            Stabilite -= 5;
            Console.WriteLine($"[VeriPaketi] Veri içeriği okundu. (Kalan: {Stabilite})");
        }
    }
}
