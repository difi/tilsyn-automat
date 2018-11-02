using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Classes.Enhetsregisteret
{
    public class EnhetsregisteretRootObject
    {
        public int organisasjonsnummer { get; set; }
        public string navn { get; set; }
        public string registreringsdatoEnhetsregisteret { get; set; }
        public string hjemmeside { get; set; }
        public string maalform { get; set; }
        public string registrertIFrivillighetsregisteret { get; set; }
        public string registrertIMvaregisteret { get; set; }
        public string registrertIForetaksregisteret { get; set; }
        public string registrertIStiftelsesregisteret { get; set; }
        public int antallAnsatte { get; set; }
        public Orgform orgform { get; set; }
        public InstitusjonellSektorkode institusjonellSektorkode { get; set; }
        public Naeringskode1 naeringskode1 { get; set; }
        public Forretningsadresse forretningsadresse { get; set; }
        public int sisteInnsendteAarsregnskap { get; set; }
        public string konkurs { get; set; }
        public string underAvvikling { get; set; }
        public string underTvangsavviklingEllerTvangsopplosning { get; set; }
        public List<Link> links { get; set; }
        public string organisasjonsform { get; set; }
    }

    public class Orgform
    {
        public string kode { get; set; }
        public string beskrivelse { get; set; }
    }

    public class InstitusjonellSektorkode
    {
        public string kode { get; set; }
        public string beskrivelse { get; set; }
    }

    public class Naeringskode1
    {
        public string kode { get; set; }
        public string beskrivelse { get; set; }
    }

    public class Forretningsadresse
    {
        public string adresse { get; set; }
        public string postnummer { get; set; }
        public string poststed { get; set; }
        public string kommunenummer { get; set; }
        public string kommune { get; set; }
        public string landkode { get; set; }
        public string land { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }
}