Bu proje, Görsel Programlama dersi final ödevi için hazırladığım, anlık döviz kurlarını takip edebileceğimiz bir konsol uygulamasıdır.

Projenin amacı, internet üzerindeki bir kaynaktan yani API'den verileri canlı olarak çekip, hafızada tutarak LINQ sorguları ile filtreleyip ekrana yazdırmaktır.

Çalışma prensibi şöyledir :

Bağlantı Kurma : Program açılır açılmaz "HttpClient" dediğimiz aracı kullanarak internete bağlanıyor. Frankfurter API servisine gidip Türk Lirası bazlı güncel döviz kurlarını istiyor.

Veriyi Dönüştürme : İnternetten gelen veri JSON formatında karışık bir düzende geliyor. Ben bu veriyi alıp, kodun içinde oluşturduğum "Currency" ve "CurrencyResponse" sınıflarına dönüştürdüm. Yani o gelen yazıyı, programın anlayacağı nesnelere çevirdim.

Menü Sistemi : Kullanıcının rahat işlem yapabilmesi için bir menü yaptım. Burada Switch-Case yapısı kullandım. Yani kullanıcı 1'e basarsa listele, 2'ye basarsa arama yap şeklinde yönlendirdim.

Arama ve Listeleme İşlemleri: Bu projede verileri yönetmek için yoğun olarak "LINQ" sorgularını kullandım.
 Listeleme yaparken verileri olduğu gibi getiriyorum.
 Kod ararken: Kullanıcının girdiği harfler (örneğin USD), döviz kodunun içinde geçiyor mu diye "Where" komutuyla kontrol ediyorum.
 Filtreleme yaparken: Girilen parasal değerden daha büyük olan kurları yine "Where" ile ayıklıyorum.
 Sıralama yaparken: "OrderBy" komutu kullanarak kurları küçükten büyüğe doğru diziyorum.
 İstatistikler: "Max", "Min" ve "Average" komutlarını kullanarak en yüksek, en düşük ve ortalama kuru hesaplatıyorum.

Programın Özellikleri:
 Program açılınca verileri otomatik olarak hafızaya alır.
 Tüm döviz kurlarını tek listede görebilirsiniz.
 Döviz koduna göre (örn: EUR, USD) arama yapabilirsiniz.
 Belirli bir değerin üzerindeki kurları filtreleyebilirsiniz.
 Kurları değerine göre sıralayabilirsiniz.
 İstatistiksel özet (En yüksek, en düşük, ortalama) alabilirsiniz.
 İnternet kesikse veya hata olursa program kapanmaz, hata mesajı verir (Try-Catch yapısından kaynaklı).

Projeyi Visual Studio 2022 ile açıp F5 tuşuna basarak çalıştırabilirsiniz. Ekstra bir ayar yapmaya gerek yoktur.

Hazırlayan: Sümeyye Çekiç - 20230108003 - BIP2
