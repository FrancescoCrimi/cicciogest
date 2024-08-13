using CiccioGest.Application.FakeImpl;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using FluentAssertions;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Xunit;

namespace CiccioGest.Test.Domain
{
    public class DataContractSerializerTest
    {
        private T SeriAndDeseri<T>(T item)
        {
            //FileStream fs = new FileStream("ArticoloDC.xml", FileMode.Create);
            MemoryStream ms = new MemoryStream();
            DataContractSerializer dcs = new DataContractSerializer(typeof(T));
            dcs.WriteObject(ms, item);
            ms.Position = 0;
            T newitem = (T)dcs.ReadObject(ms);
            ms.Close();
            return newitem;
        }

        [Fact]
        public void FatturaTest()
        {
            Fattura fatt1 = FakeSampleData.Fatture[4];
            //Fattura fatt2 = SeriAndDeseri(fatt1);

            MemoryStream ms = new MemoryStream();
            DataContractSerializer dcs = new DataContractSerializer(typeof(Fattura));
            dcs.SetSerializationSurrogateProvider(new MySerializationSurrogateProvider());
            dcs.WriteObject(ms, fatt1);
            ms.Position = 0;
            Fattura fatt2 = (Fattura)dcs.ReadObject(ms);
            ms.Close();

            Assert.Equal(fatt1.Id, fatt2.Id);
            //Assert.Equal(fatt1.IdCliente, fatt2.IdCliente);
            //Assert.Equal(fatt1.NomeCliente, fatt2.NomeCliente);
            Assert.Equal(fatt1.Totale, fatt2.Totale);
            fatt1.Dettagli.Should().BeEquivalentTo(fatt2.Dettagli);
        }

        [Fact]
        public void CategoriaTest()
        {
            Categoria cate1 = FakeSampleData.Categorie[4];
            Categoria cate2 = SeriAndDeseri(cate1);
            Assert.Equal(cate1.Id, cate2.Id);
            Assert.Equal(cate1.Nome, cate2.Nome);
            Assert.Equal(cate1, cate2);
        }

        [Fact]
        public void ArticoloTest()
        {
            Articolo arti1 = FakeSampleData.Articoli[4];
            Articolo arti2 = SeriAndDeseri(arti1);
            Assert.Equal(arti1.Id, arti2.Id);
            //Assert.Equal(arti1.IdFornitore, arti2.IdFornitore);
            Assert.Equal(arti1.Nome, arti2.Nome);
            //Assert.Equal(arti1.NomeFornitore, arti2.NomeFornitore);
            Assert.Equal(arti1.Prezzo, arti2.Prezzo);
            //arti2.Categorie.Should().BeEquivalentTo(arti1.Categorie);
            Assert.Equal(arti1, arti2);
        }

        [Fact]
        public void DettaglioTest()
        {
            Dettaglio dettaglio1 = FakeSampleData.Fatture[4].Dettagli[4];
            Dettaglio dettaglio2 = SeriAndDeseri(dettaglio1);
            Assert.Equal(dettaglio1, dettaglio2);
        }


        //void XmlSerialize()
        //{
        //    FatturaDto fatt = FakeData.Fatture[4];
        //    FileStream fs = new FileStream("Fattura.xml", FileMode.Create);
        //    XmlSerializer xs = new XmlSerializer(typeof(FatturaDto), "http://gesttest.it");
        //    xs.Serialize(fs, fatt);
        //    fs.Position = 0;
        //    fatt = (FatturaDto)xs.Deserialize(fs);
        //    fs.Close();
        //}
    }
}
