using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuantumVeriAmbari
{  
    public class KaranlikMadde : KuantumNesnesi, IKritik
    {
        public override void AnalizEt()
        {
            Stabilite -= 15;
            Console.WriteLine($"[KaranlikMadde] Analiz tamamlandı. (Kalan: {Stabilite})");
        }

        public void AcilDurumSogutmasi()
        {
            Stabilite += 50; // Setter metodu 100 kontrolünü otomatik yapar.
            Console.WriteLine($"[SOGUTMA] Karanlık madde soğutuldu. Yeni Stabilite: {Stabilite}");
        }
    }

}
