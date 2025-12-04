using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuantumVeriAmbari
{
    public class AntiMadde : KuantumNesnesi, IKritik
    {
        public override void AnalizEt()
        {
            Stabilite -= 25;
            Console.WriteLine("Evrenin dokusu titriyor...");
            Console.WriteLine($"[AntiMadde] Çok riskli analiz yapıldı! (Kalan: {Stabilite})");
        }

        public void AcilDurumSogutmasi()
        {
            Stabilite += 50;
            Console.WriteLine($"[SOGUTMA] Anti-Madde stabilize edildi. Yeni Stabilite: {Stabilite}");
        }
    }
}
