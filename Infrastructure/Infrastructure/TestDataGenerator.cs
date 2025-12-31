// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Collections.Generic;

namespace CiccioGest.Infrastructure
{
    // Definizione della struttura dati come record struct (leggera e immutabile)
    public record PersonaTest(
        string NomeCompleto,
        string Via,
        string Civico,
        string CodiceFiscale,
        string PartitaIva,
        string Telefono,
        string Email
    );

    public record CategoriaTest(int Id, string Nome, string CodiceInterno);

    // Definizione del record Articolo
    public record ArticoloTest(
        string NomeArticolo,
        decimal Prezzo,
        List<int> CategorieIds,
        int FornitoreId
    );

    public class TestDataGenerator
    {
        public static List<PersonaTest> GeneraClienti()
        {
            return
                [
                new("Mario Rossi", "Via Roma", "12", "RSSMRA80A01H501U", "IT01234567890", "+39 333 1234567", "mario.rossi@esempio.it"),
                new("Giulia Bianchi", "Corso Vittorio Emanuele II", "54/A", "BNCGLI85C41L219L", "IT09876543210", "+39 347 9876543", "giulia_bianchi@dominio.com"),
                new("Luca Verdi", "Viale della Libertà", "7", "VRDLUC75E10C351K", "IT01122334455", "+39 335 5554443", "luca.verdi@posta.it"),
                new("Anna Neri", "Via Giuseppe Garibaldi", "101", "NREANN90M66G273F", "IT06677889900", "+39 366 1122334", "anna.neri@mailserver.com"),
                new("Paolo Gallo", "Piazza Duomo", "3", "GLLPAO68S05F839A", "IT04455667788", "+39 338 0001122", "paolo.gallo@azienda.it"),
                new("Elena Contaldi", "Via Dante Alighieri", "22", "CNTELN92T50A783J", "IT03344556677", "+39 340 7766554", "elena.c@webmail.com"),
                new("Roberto Marino", "Largo Augusto", "15", "MRNRBT79B15F205W", "IT02233445566", "+39 349 1230099", "roberto.marino@studio.it"),
                new("Silvia Fontana", "Via dei Mille", "45/B", "FNTSLV88D48E514U", "IT08899001122", "+39 339 6543210", "silvia.fontana@provider.it"),
                new("Andrea Russo", "Corso Italia", "89", "RSSNDR82A17H501L", "IT07788990011", "+39 348 1122334", "a.russo@esempio.com"),
                new("Laura Esposito", "Viale Regina Margherita", "11", "SPTLRA95L50G273U", "IT05566778899", "+39 334 9988776", "laura.esposito@dominio.it"),
                new("Marco Romano", "Via Giacomo Matteotti", "33", "RMNMRC70M20F839J", "IT04433221100", "+39 333 4567890", "marco.romano@posta.it"),
                new("Chiara Costa", "Piazza della Repubblica", "8", "CSTCHR91P44C351W", "IT01100223344", "+39 347 1112233", "chiara_costa@mail.it"),
                new("Federico Ferrari", "Via Leonardo da Vinci", "156", "FRRFDC86T25L219W", "IT09988776655", "+39 338 6677889", "f.ferrari@azienda.it"),
                new("Sara Gallo", "Corso Umberto I", "21", "GLLSRA93A41H501R", "IT08877665544", "+39 340 9988776", "sara.gallo@studio.it"),
                new("Alessandro Conti", "Via Alessandro Manzoni", "5", "CNTDRS89E28B514Q", "IT07766554433", "+39 349 1122334", "a.conti@provider.it"),
                new("Valentina De Luca", "Viale Europa", "204", "DLUVLN94C45G273X", "IT06655443322", "+39 334 0001122", "valentina.deluca@webmail.com"),
                new("Giovanni Rizzo", "Via XX Settembre", "18", "RZZGNN78R18F205E", "IT05544332211", "+39 333 9988776", "g.rizzo@dominio.com"),
                new("Martina Moretti", "Piazzale Loreto", "9", "MRTMRN96S60A783L", "IT04433221100", "+39 347 5566778", "martina.moretti@posta.it"),
                new("Davide Testa", "Via Cavour", "67", "TSTDVD83P21H501C", "IT03322110099", "+39 335 1234567", "davide.testa@mail.it"),
                new("Chiara Ferretti", "Viale dei Caduti", "2", "FRRCHR87A01B514Z", "IT02211009988", "+39 366 9988776", "chiara.ferretti@azienda.it"),
                new("Giuseppe Amato", "Via Giosuè Carducci", "44", "MTAGPP72C15L219Y", "IT01100998877", "+39 338 1234567", "giuseppe.amato@studio.it"),
                new("Francesca Russo", "Piazza San Marco", "1", "RSSFRN90T55F205A", "IT09988776655", "+39 340 5544332", "francesca.russo@provider.it"),
                new("Antonio Bruno", "Via Torino", "123", "BRNNTN81A10H501R", "IT08877665544", "+39 349 9988776", "antonio.bruno@webmail.com"),
                new("Maria Gallo", "Corso Buenos Aires", "10", "GLLMRA76C55G273X", "IT07766554433", "+39 334 1122334", "maria.gallo@dominio.com"),
                new("Simone Messina", "Via Francesco Crispi", "56", "MSSSMN84M05C351B", "IT06655443322", "+39 333 4455667", "s.messina@posta.it"),
                new("Laura Sala", "Viale Tunisia", "28", "SLALRA97A48A783J", "IT05544332211", "+39 347 6677889", "laura.sala@mail.it"),
                new("Roberto Leone", "Via dei Condotti", "72/C", "LNERBT71A12B514Q", "IT04433221100", "+39 338 0009988", "roberto.leone@azienda.it"),
                new("Elisabetta Rosati", "Piazza Navona", "14", "RSTLBT85A49F205W", "IT03322110099", "+39 340 1234567", "elisabetta.rosati@studio.it"),
                new("Andrea Villa", "Via Etnea", "310", "VLLNDR92S01H501E", "IT02211009988", "+39 349 5566778", "a.villa@provider.it"),
                new("Daniela Ferrara", "Via Posillipo", "19", "FRRDNL93M41L219P", "IT01100998877", "+39 334 9988776", "daniela.ferrara@webmail.com"),
                new("Marco Lombardi", "Corso Ruggero Segnano", "4", "LMBMRC80R19G273F", "IT09988776655", "+39 333 1122334", "marco.lombardi@dominio.com"),
                new("Alessia Caputo", "Via Zamboni", "33", "CPTLSS87M45C351K", "IT08877665544", "+39 347 0001122", "alessia.caputo@posta.it"),
                new("Fabio Greco", "Via Indipendenza", "20", "GRCFBA82T01A783R", "IT07766554433", "+39 335 9988776", "fabio.greco@mail.it"),
                new("Chiara Mancini", "Viale Trastevere", "88", "MNCCRH94P55B514U", "IT06655443322", "+39 366 1234567", "chiara.mancini@azienda.it"),
                new("Matteo Ricci", "Via della Conciliazione", "12", "RCCMTT85A10F205J", "IT05544332211", "+39 338 6543210", "matteo.ricci@studio.it"),
                new("Laura Vitale", "Piazza De Ferrari", "5", "VTLLRA91L50H501E", "IT04433221100", "+39 340 1122334", "laura.vitale@provider.it"),
                new("Giuseppe Longo", "Via Balbi", "110", "LNGGPP77A05L219A", "IT03322110099", "+39 349 0009988", "g.longo@webmail.com"),
                new("Elena Moretti", "Via San Vincenzo", "42", "MRTNLN84E48G273W", "IT02211009988", "+39 334 5566778", "elena.moretti@dominio.com"),
                new("Marco Gallo", "Corso Giovecca", "77", "GLLMRC88T23C351Z", "IT01100998877", "+39 333 9988776", "marco.gallo@posta.it"),
                new("Silvia Testa", "Via dei Tribunali", "15", "TSTSLV90S42A783L", "IT09988776655", "+39 347 1234567", "silvia.testa@mail.it"),
                new("Davide Bianchi", "Via dell'Indipendenza", "1", "BNCVDV82M18B514Q", "IT08877665544", "+39 335 0001122", "davide.bianchi@azienda.it"),
                new("Chiara Romano", "Via Emilia", "150", "RMNCHR95A50F205U", "IT07766554433", "+39 366 5544332", "chiara.romano@studio.it"),
                new("Antonio Conti", "Corso della Vittoria", "33", "CNTNTN87R04H501W", "IT06655443322", "+39 338 9988776", "antonio.conti@provider.it"),
                new("Maria De Luca", "Via Veneto", "2", "DLUMRA90L50L219E", "IT05544332211", "+39 340 1122334", "maria.deluca@webmail.com"),
                new("Giuseppe Ferrara", "Viale delle Scienze", "4", "FRRGPP75P12G273R", "IT04433221100", "+39 349 0009988", "giuseppe.ferrara@dominio.com"),
                new("Elena Greco", "Via Cavour", "1", "GRCLNN88A41C351B", "IT03322110099", "+39 334 5566778", "elena.greco@posta.it"),
                new("Marco Messina", "Via Roma", "45", "MSSMRC91S01A783J", "IT02211009988", "+39 333 9988776", "marco.messina@mail.it"),
                new("Silvia Sala", "Corso Umberto I", "1", "SLASLV94T55B514Q", "IT01100998877", "+39 347 1234567", "silvia.sala@azienda.it"),
                new("Davide Villa", "Piazza del Popolo", "10", "VLLDVD86R20F205W", "IT09988776655", "+39 335 0001122", "davide.villa@studio.it"),
                new("Chiara Amato", "Via Ghibellina", "78", "MTACRH89M51H501C", "IT08877665544", "+39 366 9988776", "chiara.amato@provider.it")
                ];
        }


        public static List<PersonaTest> GeneraFornitori()
        {
            return
                [
                new("TecnoSistemi Italia S.r.l.", "Via dell'Industria", "15", "TCSITA80A01H501U", "IT01234567890", "+39 02 1234567", "info@tecnosistemi.it"),
                new("Logistica Mediterranea S.p.A.", "Viale dei Trasporti", "88", "LGMEDT85C41L219L", "IT09876543210", "+39 06 9876543", "amministrazione@logistica.it"),
                new("Edilizia Moderna di Rossi & C. S.n.c.", "Via dei Muratori", "4", "EDLMOD75E10C351K", "IT01122334455", "+39 011 5554443", "contatti@edilizia-moderna.com"),
                new("Global Service Solution S.r.l.", "Corso Europa", "101/B", "GLBSVC90M66G273F", "IT06677889900", "+39 081 1122334", "sales@globalservice.it"),
                new("Arredamenti d'Elite S.p.A.", "Via degli Artigiani", "22", "ARDELT68S05F839A", "IT04455667788", "+39 045 0001122", "commerciale@arredamentielite.it"),
                new("Nova Energia Rinnovabile S.r.l.", "Largo delle Fonti", "7", "NVAERG92T50A783J", "IT03344556677", "+39 051 7766554", "green@novaenergia.it"),
                new("Distribuzione Alimentari Marino S.r.l.", "Via del Commercio", "33", "DSTALM79B15F205W", "IT02233445566", "+39 010 1230099", "logistica@marino-food.it"),
                new("Pulizie Splendenti S.c.a.r.l.", "Via della Cooperazione", "12", "PLZSPL88D48E514U", "IT08899001122", "+39 02 6543210", "info@puliziesplendenti.it"),
                new("Grafiche e Design S.r.l.", "Viale della Tipografia", "56", "GRFDSN82A17H501L", "IT07788990011", "+39 049 1122334", "studio@grafichedesign.it"),
                new("Consulenze Aziendali Milano S.p.A.", "Piazza Affari", "10", "CNSMIL95L50G273U", "IT05566778899", "+39 02 9988776", "info@cam-consulenza.it"),
                new("Sicurezza Totale S.r.l.", "Via delle Guardie", "2", "SCRTOT70M20F839J", "IT04433221100", "+39 06 4567890", "security@sicurezzatotale.it"),
                new("AutoRicambi Nazionali S.p.A.", "Via dei Motori", "144", "AUTRCN91P44C351W", "IT01100223344", "+39 011 1112233", "ordini@autoricambi.com"),
                new("Idraulica & Clima S.n.c.", "Via dei Tubi", "21", "IDRCLI86T25L219W", "IT09988776655", "+39 055 6677889", "tecnico@idraulica-clima.it"),
                new("Informatica Pro S.r.l.", "Via dei Microchip", "9", "INFPRO93A41H501R", "IT08877665544", "+39 02 9988776", "support@informaticapro.it"),
                new("Trasporti Rapidi Veloci S.r.l.", "Viale dello Scalo", "5", "TRPVLV89E28B514Q", "IT07766554433", "+39 081 1122334", "spedizioni@trv.it"),
                new("Cartaria Veneta S.p.A.", "Via del Macero", "120", "CRTVNT94C45G273X", "IT06655443322", "+39 041 0001122", "acquisti@cartariaveneta.it"),
                new("Studio Legale Associato Bianchi", "Corso Cavour", "18", "STALAB78R18F205E", "IT05544332211", "+39 059 9988776", "segreteria@studiobianchi.it"),
                new("Elettroforniture Nord S.r.l.", "Via dei Cavi", "3", "ELFNOD96S60A783L", "IT04433221100", "+39 02 5566778", "vendite@ef-nord.it"),
                new("Tessuti Pregiati Como S.p.A.", "Via della Seta", "45", "TSPRCO83P21H501C", "IT03322110099", "+39 031 1234567", "export@tessuticomo.it"),
                new("Packaging Eco S.r.l.", "Viale del Riciclo", "28", "PCKECO87A01B514Z", "IT02211009988", "+39 0522 9988776", "green@packagingeco.it"),
                new("Ristorazione Collettiva S.p.A.", "Piazza delle Erbe", "11", "RSTCOL72C15L219Y", "IT01100998877", "+39 02 1234567", "mensa@ristocoll.it"),
                new("Impresa Edile Scaligera S.r.l.", "Via Verona", "67", "IMPSCA90T55F205A", "IT09988776655", "+39 045 5544332", "info@edilescaligera.it"),
                new("Software Factory Italia S.r.l.", "Via del Silicio", "312", "SWFITA81A10H501R", "IT08877665544", "+39 02 9988776", "dev@swfactory.it"),
                new("Forniture Ufficio Express S.p.A.", "Corso della Liberta", "9", "FORUFF76C55G273X", "IT07766554433", "+39 06 1122334", "ordini@ufficioexpress.it"),
                new("Meccanica di Precisione G.B. S.r.l.", "Via dei Tornitori", "56", "MECPRE84M05C351B", "IT06655443322", "+39 051 4455667", "produzione@meccanicaprecisione.it"),
                new("Impianti Fotovoltaici Sun S.r.l.", "Viale del Sole", "20", "IMPSUN97A48A783J", "IT05544332211", "+39 071 6677889", "info@fotovoltaicosun.it"),
                new("Marmi e Graniti S.p.A.", "Via della Cava", "2", "MRMGRA71A12B514Q", "IT04433221100", "+39 0585 0009988", "amministrazione@marmispa.it"),
                new("Consulenza Fiscale Associata", "Via dei Tributi", "14", "CNFIS85A49F205W", "IT03322110099", "+39 02 1234567", "clienti@consulenzafiscale.it"),
                new("Vivaio Verde S.r.l.", "Via dei Fiori", "230", "VIVVER92S01H501E", "IT02211009988", "+39 055 5566778", "ordini@vivaioverde.it"),
                new("Catering d'Eccellenza S.r.l.", "Via del Gusto", "19", "CATEXC93M41L219P", "IT01100998877", "+39 081 9988776", "eventi@cateringeccellenza.it"),
                new("Gestione Rifiuti Urbani S.p.A.", "Via dell'Ecologia", "4", "GESRIF80R19G273F", "IT09988776655", "+39 06 1122334", "info@gestorerifiuti.it"),
                new("Telecomunicazioni Avanzate S.r.l.", "Largo delle Antenne", "33", "TLCAVA87M45C351K", "IT08877665544", "+39 02 0001122", "business@telecomavanzate.it"),
                new("Assicurazioni Globali S.p.A.", "Piazza della Vittoria", "20", "ASSGLB82T01A783R", "IT07766554433", "+39 011 9988776", "polizze@assicurazioniglobali.it"),
                new("Manutenzioni Ascensori S.r.l.", "Via dei Palazzi", "88", "MNASC85A10F205J", "IT06655443322", "+39 02 6543210", "tecnico@manutenzioniascensori.it"),
                new("Ingrosso Carta e Plastica S.n.c.", "Via dell'Imballo", "12", "INGCAP94P55B514U", "IT05544332211", "+39 035 6543210", "info@ingrossocarta.it"),
                new("Serramenti Sicuri S.p.A.", "Via dei Fabbri", "5", "SERSIC91L50H501E", "IT04433221100", "+39 049 1122334", "preventivi@serramentisicuri.it"),
                new("Laboratorio Analisi Chimiche S.r.l.", "Via della Scienza", "110", "LABANA77A05L219A", "IT03322110099", "+39 02 0009988", "analisi@laboratoriochimico.it"),
                new("Arredamento Contract S.r.l.", "Viale dei Mobili", "42", "ARRCON84E48G273W", "IT02211009988", "+39 0721 5566778", "info@arredamentocontract.it"),
                new("Materiali Isolanti S.p.A.", "Via del Calore", "77", "MATISO88T23C351Z", "IT01100998877", "+39 0532 9988776", "commerciale@materialiisolanti.it"),
                new("Forniture Alberghiere S.r.l.", "Via della Spiaggia", "15", "FORALB90S42A783L", "IT09988776655", "+39 0541 1234567", "info@hotel-forniture.it"),
                new("Impresa di Pulizie Aurora S.r.l.", "Via della Luna", "1", "IMPAPR82M18B514Q", "IT08877665544", "+39 02 0001122", "info@pulizieaurora.it"),
                new("Sistemi di Allarme Delta S.p.A.", "Corso Sicurezza", "150", "SISALM95A50F205U", "IT07766554433", "+39 06 5544332", "delta@allarmispa.it"),
                new("AutoLavaggi Professionali S.r.l.", "Via dell'Acqua", "33", "AUTLAV87R04H501W", "IT06655443322", "+39 02 9988776", "commerciale@autolavaggipro.it"),
                new("Energie Verdi S.p.A.", "Largo Rinnovabili", "2", "ENRVER90L50L219E", "IT05544332211", "+39 011 1122334", "green@energiverdispa.it"),
                new("Officina Meccanica Rossi S.n.c.", "Via dei Bulloni", "4", "OFFMEC75P12G273R", "IT04433221100", "+39 045 0009988", "tecnico@officinarossi.it"),
                new("Marketing & Comunicazione S.r.l.", "Via dei Social", "1", "MRKCOM88A41C351B", "IT03322110099", "+39 02 5566778", "info@marketing-com.it"),
                new("Hardware & Networking S.p.A.", "Via del Web", "45", "HWNETW91S01A783J", "IT02211009988", "+39 02 9988776", "it-support@hwnetwork.it"),
                new("Climatizzazione Estiva S.r.l.", "Viale del Freddo", "1", "CLMEST94T55B514Q", "IT01100998877", "+39 049 1234567", "info@climaestivo.it"),
                new("Pratiche Amministrative S.n.c.", "Piazza del Comune", "10", "PRAMMN86R20F205W", "IT09988776655", "+39 051 0001122", "pratiche@ufficiopratiche.it"),
                new("Imballaggi Industriali S.r.l.", "Via del Cartone", "78", "IMBIN89M51H501C", "IT08877665544", "+39 011 9988776", "info@imballaggi-ind.it")
                ];
        }


        public static List<CategoriaTest> GeneraCategorie()
        {
            return
            [
                new(1, "Alimentari e Bevande", "ALM-001"),
                new(2, "Arredamento e Design", "ARR-002"),
                new(3, "Articoli da Regalo", "REG-003"),
                new(4, "Abbigliamento Uomo", "ABB-U04"),
                new(5, "Abbigliamento Donna", "ABB-D05"),
                new(6, "Abbigliamento Bambino", "ABB-B06"),
                new(7, "Calzature", "CAL-007"),
                new(8, "Pelletteria e Accessori", "PEL-008"),
                new(9, "Elettronica di Consumo", "ELE-009"),
                new(10, "Informatica e Software", "INF-010"),
                new(11, "Elettrodomestici", "ELM-011"),
                new(12, "Telefonia", "TEL-012"),
                new(13, "Ferramenta e Utensileria", "FER-013"),
                new(14, "Materiali Edili", "EDI-014"),
                new(15, "Idraulica e Termoidraulica", "IDR-015"),
                new(16, "Elettricità e Illuminazione", "ELT-016"),
                new(17, "Cartoleria e Forniture Ufficio", "OFF-017"),
                new(18, "Giocattoli e Modellismo", "GIO-018"),
                new(19, "Articoli Sportivi", "SPO-019"),
                new(20, "Biciclette e Accessori", "BCI-020"),
                new(21, "Ricambi Auto e Moto", "MOT-021"),
                new(22, "Pneumatici", "PNE-022"),
                new(23, "Cosmetica e Profumeria", "COS-023"),
                new(24, "Prodotti per l'Igiene", "IGI-024"),
                new(25, "Farmaci e Parafarmaci", "FAR-025"),
                new(26, "Ottica e Fotografia", "OTT-026"),
                new(27, "Gioielleria e Orologeria", "GIO-027"),
                new(28, "Libri e Riviste", "LIB-028"),
                new(29, "Strumenti Musicali", "MUS-029"),
                new(30, "Giardinaggio e Agricoltura", "GIA-030"),
                new(31, "Mangimi e Prodotti Animali", "PET-031"),
                new(32, "Fiori e Piante", "FLO-032"),
                new(33, "Prodotti per la Pulizia Industriale", "PUL-033"),
                new(34, "Antinfortunistica e DPI", "SIC-034"),
                new(35, "Imballaggi e Confezionamento", "PKG-035"),
                new(36, "Macchinari Industriali", "MAC-036"),
                new(37, "Componenti Elettronici", "COM-037"),
                new(38, "Tessuti e Filati", "TES-038"),
                new(39, "Prodotti Chimici", "CHI-039"),
                new(40, "Materie Plastiche", "PLA-040"),
                new(41, "Legname e Derivati", "LEG-041"),
                new(42, "Metalli e Semilavorati", "MET-042"),
                new(43, "Strumenti di Misura", "MIS-043"),
                new(44, "Attrezzature per Ristorazione", "HO-044"),
                new(45, "Forniture Alberghiere", "HO-045"),
                new(46, "Arredo Urbano", "URB-046"),
                new(47, "Sistemi di Sicurezza", "SEC-047"),
                new(48, "Energie Rinnovabili", "GRN-048"),
                new(49, "Combustibili e Lubrificanti", "OIL-049"),
                new(50, "Trattamento Acque", "H2O-050")
            ];
        }


        public static List<ArticoloTest> GeneraArticoli()
        {
            return
                [
                new("Trapano a percussione 800W", 89.99m, new() { 13, 16 }, 1),
                new("Set 10 sedie ufficio ergonomiche", 1250.00m, new() { 2, 17, 45 }, 5),
                new("Monitor 27 pollici 4K", 349.50m, new() { 10, 9 }, 14),
                new("Pasta di Gragnano 500g (conf. 20)", 45.00m, new() { 1 }, 7),
                new("Cavo elettrico tripolare 50m", 35.20m, new() { 16, 15, 14 }, 18),
                new("Scarpe antinfortunistiche S3", 65.00m, new() { 34, 7 }, 40),
                new("Smartphone Business 128GB", 599.00m, new() { 12, 10, 9 }, 14),
                new("Lampada LED soffitto industriale", 120.00m, new() { 16, 46 }, 18),
                new("Saldatrice a filo inverter", 210.00m, new() { 13, 36, 42 }, 25),
                new("Detersivo pavimenti 5L (x4)", 38.40m, new() { 33, 24 }, 8),
                new("Scrivania in rovere massiccio", 450.00m, new() { 2, 41 }, 5),
                new("Router WiFi 6 Mesh", 189.99m, new() { 10, 12, 47 }, 23),
                new("Pannello Fotovoltaico 400W", 155.00m, new() { 48, 16 }, 6),
                new("Olio motore sintetico 5L", 55.00m, new() { 21, 49 }, 21),
                new("Calce idrata sacco 25kg", 8.50m, new() { 14, 39 }, 22),
                new("Valvola termostatica smart", 42.00m, new() { 15, 48 }, 13),
                new("Set chiavi inglesi professionali", 78.50m, new() { 13 }, 25),
                new("Carta A4 80g (box 5 risme)", 24.50m, new() { 17, 35 }, 16),
                new("Stampante laser multifunzione", 299.00m, new() { 10, 17, 11 }, 14),
                new("Trapano avvitatore a batteria", 115.00m, new() { 13, 37 }, 1),
                new("Guanti in lattice (box 100)", 12.90m, new() { 24, 25, 34 }, 37),
                new("Siero viso acido ialuronico", 28.00m, new() { 23, 24 }, 10),
                new("Tastiera meccanica retroilluminata", 85.00m, new() { 10, 9 }, 23),
                new("Compressore aria 24L", 145.00m, new() { 13, 36 }, 45),
                new("Scaffale metallico componibile", 55.00m, new() { 2, 14, 42 }, 3),
                new("Vino Chianti DOCG (cassa 6)", 72.00m, new() { 1 }, 30),
                new("Telecamera sicurezza IP 4K", 110.00m, new() { 47, 9, 10 }, 42),
                new("Climatizzatore 12000 BTU", 480.00m, new() { 15, 11, 48 }, 48),
                new("Idropulitrice acqua fredda", 195.00m, new() { 13, 33, 50 }, 45),
                new("Caffè in grani 1kg (x10)", 135.00m, new() { 1, 44 }, 21),
                new("Zaino porta PC impermeabile", 45.00m, new() { 8, 4, 10 }, 4),
                new("Trapano a colonna professionale", 850.00m, new() { 36, 13, 42 }, 25),
                new("Cassa acustica Bluetooth", 65.00m, new() { 9, 29 }, 9),
                new("Concime universale 20kg", 32.00m, new() { 30, 31, 39 }, 29),
                new("Manometro pressione gomme", 15.00m, new() { 43, 21 }, 45),
                new("Estintore a polvere 6kg", 48.00m, new() { 34, 47 }, 11),
                new("Tavolo da riunione 3 metri", 890.00m, new() { 2, 45 }, 5),
                new("Elettropompa sommersa", 165.00m, new() { 15, 50, 16 }, 13),
                new("Bobina filo acciaio 5km", 110.00m, new() { 42, 38, 14 }, 39),
                new("Microfono a condensatore USB", 125.00m, new() { 29, 9, 10 }, 47),
                new("Lampadina smart RGB E27", 18.50m, new() { 16, 48 }, 18),
                new("Giacca da lavoro alta visibilità", 55.00m, new() { 34, 4 }, 22),
                new("Misuratore laser 50m", 62.00m, new() { 43, 14, 13 }, 49),
                new("Viti Parker acciaio (1000 pz)", 22.00m, new() { 13, 42 }, 1),
                new("Pennelli set 5 pezzi", 14.50m, new() { 14, 3 }, 3),
                new("Aspirapolvere industriale", 320.00m, new() { 33, 11, 36 }, 41),
                new("Hard Disk Esterno 5TB", 145.00m, new() { 10, 9 }, 47),
                new("Scaldabagno elettrico 80L", 185.00m, new() { 15, 11 }, 13),
                new("Pellet faggio sacco 15kg", 7.90m, new() { 49, 41 }, 20),
                new("Casco protettivo cantiere", 25.00m, new() { 34, 14 }, 11)
                ];
        }
    }
}

