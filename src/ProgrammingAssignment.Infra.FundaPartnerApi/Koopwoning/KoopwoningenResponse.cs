﻿namespace ProgrammingAssignment.Infra.FundaPartnerApi.Koopwoning;

public class KoopwoningenResponse
{
    public int? AccountStatus { get; set; }
    public bool? EmailNotConfirmed { get; set; }
    public bool? ValidationFailed { get; set; }
    public object? ValidationReport { get; set; }
    public int? Website { get; set; }
    public Metadata? Metadata { get; set; }
    public Objects[] Objects { get; set; }
    public Paging? Paging { get; set; }
    public int? TotaalAantalObjecten { get; set; }
}

public class Metadata
{
    public string? ObjectType { get; set; }
    public string? Omschrijving { get; set; }
    public string? Titel { get; set; }
}

public class Objects
{
    public string? AangebodenSindsTekst { get; set; }
    public string? AanmeldDatum { get; set; }
    public object? AantalBeschikbaar { get; set; }
    public int? AantalKamers { get; set; }
    public object? AantalKavels { get; set; }
    public string? Aanvaarding { get; set; }
    public string? Adres { get; set; }
    public int? Afstand { get; set; }
    public string? BronCode { get; set; }
    public object[] ChildrenObjects { get; set; }
    public object? DatumAanvaarding { get; set; }
    public object? DatumOndertekeningAkte { get; set; }
    public string? Foto { get; set; }
    public string? FotoLarge { get; set; }
    public string? FotoLargest { get; set; }
    public string? FotoMedium { get; set; }
    public string? FotoSecure { get; set; }
    public object? GewijzigdDatum { get; set; }
    public int? GlobalId { get; set; }
    public string? GroupByObjectType { get; set; }
    public bool? Heeft360GradenFoto { get; set; }
    public bool? HeeftBrochure { get; set; }
    public bool? HeeftOpenhuizenTopper { get; set; }
    public bool? HeeftOverbruggingsgrarantie { get; set; }
    public bool? HeeftPlattegrond { get; set; }
    public bool? HeeftTophuis { get; set; }
    public bool? HeeftVeiling { get; set; }
    public bool? HeeftVideo { get; set; }
    public object? HuurPrijsTot { get; set; }
    public object? Huurprijs { get; set; }
    public object? HuurprijsFormaat { get; set; }
    public string? Id { get; set; }
    public object? InUnitsVanaf { get; set; }
    public bool? IndProjectObjectType { get; set; }
    public object? IndTransactieMakelaarTonen { get; set; }
    public bool? IsSearchable { get; set; }
    public bool? IsVerhuurd { get; set; }
    public bool? IsVerkocht { get; set; }
    public bool? IsVerkochtOfVerhuurd { get; set; }
    public int? Koopprijs { get; set; }
    public string? KoopprijsFormaat { get; set; }
    public int? KoopprijsTot { get; set; }
    public object? Land { get; set; }
    public int? MakelaarId { get; set; }
    public string? MakelaarNaam { get; set; }
    public string? MobileURL { get; set; }
    public object? Note { get; set; }
    public string[] OpenHuis { get; set; }
    public int? Oppervlakte { get; set; }
    public int? Perceeloppervlakte { get; set; }
    public string? Postcode { get; set; }
    public Prijs? Prijs { get; set; }
    public string? PrijsGeformatteerdHtml { get; set; }
    public string? PrijsGeformatteerdTextHuur { get; set; }
    public string? PrijsGeformatteerdTextKoop { get; set; }
    public string[] Producten { get; set; }
    public Project? Project { get; set; }
    public object? ProjectNaam { get; set; }
    public PromoLabel? PromoLabel { get; set; }
    public string? PublicatieDatum { get; set; }
    public int? PublicatieStatus { get; set; }
    public object? SavedDate { get; set; }
    public string? Soort_aanbod { get; set; }
    public int? SoortAanbod { get; set; }
    public object? StartOplevering { get; set; }
    public object? TimeAgoText { get; set; }
    public object? TransactieAfmeldDatum { get; set; }
    public object? TransactieMakelaarId { get; set; }
    public object? TransactieMakelaarNaam { get; set; }
    public int? TypeProject { get; set; }
    public string? URL { get; set; }
    public string? VerkoopStatus { get; set; }
    public double? WGS84_X { get; set; }
    public double? WGS84_Y { get; set; }
    public int? WoonOppervlakteTot { get; set; }
    public int? Woonoppervlakte { get; set; }
    public string? Woonplaats { get; set; }
    public int[] ZoekType { get; set; }
}

public class Prijs
{
    public bool? GeenExtraKosten { get; set; }
    public string? HuurAbbreviation { get; set; }
    public object? Huurprijs { get; set; }
    public string? HuurprijsOpAanvraag { get; set; }
    public object? HuurprijsTot { get; set; }
    public string? KoopAbbreviation { get; set; }
    public int? Koopprijs { get; set; }
    public string? KoopprijsOpAanvraag { get; set; }
    public int? KoopprijsTot { get; set; }
    public object? OriginelePrijs { get; set; }
    public string? VeilingText { get; set; }
}

public class Project
{
    public object? AantalKamersTotEnMet { get; set; }
    public object? AantalKamersVan { get; set; }
    public object? AantalKavels { get; set; }
    public object? Adres { get; set; }
    public object? FriendlyUrl { get; set; }
    public object? GewijzigdDatum { get; set; }
    public object? GlobalId { get; set; }
    public string? HoofdFoto { get; set; }
    public bool? IndIpix { get; set; }
    public bool? IndPDF { get; set; }
    public bool? IndPlattegrond { get; set; }
    public bool? IndTop { get; set; }
    public bool? IndVideo { get; set; }
    public string? InternalId { get; set; }
    public object? MaxWoonoppervlakte { get; set; }
    public object? MinWoonoppervlakte { get; set; }
    public object? Naam { get; set; }
    public object? Omschrijving { get; set; }
    public object[] OpenHuizen { get; set; }
    public object? Plaats { get; set; }
    public object? Prijs { get; set; }
    public object? PrijsGeformatteerd { get; set; }
    public object? PublicatieDatum { get; set; }
    public int? Type { get; set; }
    public object? Woningtypen { get; set; }
}

public class PromoLabel
{
    public bool? HasPromotionLabel { get; set; }
    public string[] PromotionPhotos { get; set; }
    public string[] PromotionPhotosSecure { get; set; }
    public int? PromotionType { get; set; }
    public int? RibbonColor { get; set; }
    public object? RibbonText { get; set; }
    public string? Tagline { get; set; }
}

public class Paging
{
    public int? AantalPaginas { get; set; }
    public int? HuidigePagina { get; set; }
    public string? VolgendeUrl { get; set; }
    public object? VorigeUrl { get; set; }
}