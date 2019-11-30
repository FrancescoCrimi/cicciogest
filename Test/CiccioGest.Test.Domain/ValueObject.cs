using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using Moq;
using Xunit;

namespace CiccioGest.Test.Domain
{
    public class ValueObject
    {
        [Fact]
        public void DettaglioTest()
        {
            /* 
             * Gli oggetti Moqqati ritornano GetHashcode 0.
             * Per verificare un valueObject che si referenzia attraverso un 
             * entità serve una vera entità
             */
            //var moq1 = new Mock<Articolo>();
            //moq1.Setup(a => a.Id).Returns(1);
            //Dettaglio det1 = new Dettaglio(moq1.Object, 1);
            //Dettaglio det11 = new Dettaglio(moq1.Object, 2);

            Articolo art1 = new Articolo(1, "asdfg", 10);
            Dettaglio det1 = new Dettaglio(art1, 1);
            Dettaglio det11 = new Dettaglio(art1, 2);
            Assert.Equal(det1, det11);

            //var moq2 = new Mock<Articolo>();
            //moq2.Setup(a => a.Id).Returns(2);

            Articolo art2 = new Articolo(2, "asdfg", 10);
            Dettaglio det2 = new Dettaglio(art2, 1);
            Assert.NotEqual(det1, det2);
        }

        //[Fact]
        //public void IndirizzoTest()
        //{
        //    var moqCitta1 = new Mock<Citta>();
        //    moqCitta1.Setup(c => c.Id).Returns(1);
        //    Indirizzo ind1 = new Indirizzo("via1", "123", moqCitta1.Object);
        //    Indirizzo ind11 = new Indirizzo("via1", "123", moqCitta1.Object);
        //    Assert.Equal(ind1, ind11);

        //    Indirizzo ind2 = new Indirizzo("via2", "123", moqCitta1.Object);
        //    Assert.NotEqual(ind1, ind2);

        //    Indirizzo ind3 = new Indirizzo("via1", "124", moqCitta1.Object);
        //    Assert.NotEqual(ind1, ind3);

        //    var moqCitta2 = new Mock<Citta>();
        //    moqCitta2.Setup(c => c.Id).Returns(2);
        //    Indirizzo ind4 = new Indirizzo("via1", "123", moqCitta2.Object);
        //    Assert.NotEqual(ind1, ind4);
        //}
    }
}
