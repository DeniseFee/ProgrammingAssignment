using ProgrammingAssignment.Infra.FundaPartnerApi.Koopwoning;

namespace ProgrammingAssignment.Infra.FundaPartnerApi.Tests;

public class KoopwoningenResponseBuilder
{
    private int _accountStatus = 1;
    private bool _emailNotConfirmed = false;
    private bool _validationFailed = false;
    private object _validationReport = null;
    private int _website = 1;
    private Metadata _metadata = new MetadataBuilder().Build();
    private Objects[] _objects = Array.Empty<Objects>();
    private Paging _paging = new PagingBuilder().Build();
    private int _totaalAantalObjecten = 0;

    public KoopwoningenResponseBuilder WithAccountStatus(int accountStatus)
    {
        _accountStatus = accountStatus;
        return this;
    }

    public KoopwoningenResponseBuilder WithEmailNotConfirmed(bool emailNotConfirmed)
    {
        _emailNotConfirmed = emailNotConfirmed;
        return this;
    }

    public KoopwoningenResponseBuilder WithValidationFailed(bool validationFailed)
    {
        _validationFailed = validationFailed;
        return this;
    }

    public KoopwoningenResponseBuilder WithValidationReport(object validationReport)
    {
        _validationReport = validationReport;
        return this;
    }

    public KoopwoningenResponseBuilder WithWebsite(int website)
    {
        _website = website;
        return this;
    }

    public KoopwoningenResponseBuilder WithMetadata(Metadata metadata)
    {
        _metadata = metadata;
        return this;
    }

    public KoopwoningenResponseBuilder WithObjects(Objects[] objects)
    {
        _objects = objects;
        return this;
    }

    public KoopwoningenResponseBuilder WithPaging(Paging paging)
    {
        _paging = paging;
        return this;
    }

    public KoopwoningenResponseBuilder WithTotaalAantalObjecten(int totaalAantalObjecten)
    {
        _totaalAantalObjecten = totaalAantalObjecten;
        return this;
    }

    public KoopwoningenResponse Build()
    {
        return new KoopwoningenResponse
        {
            AccountStatus = _accountStatus,
            EmailNotConfirmed = _emailNotConfirmed,
            ValidationFailed = _validationFailed,
            ValidationReport = _validationReport,
            Website = _website,
            Metadata = _metadata,
            Objects = _objects,
            Paging = _paging,
            TotaalAantalObjecten = _totaalAantalObjecten
        };
    }
}

public class MetadataBuilder
{
    private string _objectType = "DefaultType";
    private string _omschrijving = "Default description";
    private string _titel = "Default title";

    public MetadataBuilder WithObjectType(string objectType)
    {
        _objectType = objectType;
        return this;
    }

    public MetadataBuilder WithOmschrijving(string omschrijving)
    {
        _omschrijving = omschrijving;
        return this;
    }

    public MetadataBuilder WithTitel(string titel)
    {
        _titel = titel;
        return this;
    }

    public Metadata Build()
    {
        return new Metadata
        {
            ObjectType = _objectType,
            Omschrijving = _omschrijving,
            Titel = _titel
        };
    }
}

public class ObjectsBuilder
{
    private string _aangebodenSindsTekst = "Default Text";
    private string _adres = "Default Address";
    private int _koopprijs = 100000;
    private int _makelaarId = 1;
    private string _makelaarNaam = "Default Makelaar";
    private bool _isVerhuurd = false;
    private bool _isVerkocht = false;
    private bool _isVerkochtOfVerhuurd = false;

    public ObjectsBuilder WithAangebodenSindsTekst(string text)
    {
        _aangebodenSindsTekst = text;
        return this;
    }

    public ObjectsBuilder WithAdres(string adres)
    {
        _adres = adres;
        return this;
    }

    public ObjectsBuilder WithKoopprijs(int koopprijs)
    {
        _koopprijs = koopprijs;
        return this;
    }

    public ObjectsBuilder WithMakelaarId(int makelaarId)
    {
        _makelaarId = makelaarId;
        return this;
    }

    public ObjectsBuilder WithMakelaarNaam(string makelaarNaam)
    {
        _makelaarNaam = makelaarNaam;
        return this;
    }

    public ObjectsBuilder WithIsVerhuurd(bool isVerhuurd)
    {
        _isVerhuurd = isVerhuurd;
        return this;
    }

    public ObjectsBuilder WithIsVerkocht(bool isVerkocht)
    {
        _isVerkocht = isVerkocht;
        return this;
    }

    public ObjectsBuilder WithIsVerkochtOfVerhuurd(bool isVerkochtOfVerhuurd)
    {
        _isVerkochtOfVerhuurd = isVerkochtOfVerhuurd;
        return this;
    }

    public Objects Build()
    {
        return new Objects
        {
            AangebodenSindsTekst = _aangebodenSindsTekst,
            Adres = _adres,
            Koopprijs = _koopprijs,
            MakelaarId = _makelaarId,
            MakelaarNaam = _makelaarNaam,
            IsVerhuurd = _isVerhuurd,
            IsVerkocht = _isVerkocht,
            IsVerkochtOfVerhuurd = _isVerkochtOfVerhuurd
        };
    }
}

public class PrijsBuilder
{
    private bool _geenExtraKosten = false;
    private int _koopprijs = 100000;

    public PrijsBuilder WithGeenExtraKosten(bool geenExtraKosten)
    {
        _geenExtraKosten = geenExtraKosten;
        return this;
    }

    public PrijsBuilder WithKoopprijs(int koopprijs)
    {
        _koopprijs = koopprijs;
        return this;
    }

    public Prijs Build()
    {
        return new Prijs
        {
            GeenExtraKosten = _geenExtraKosten,
            Koopprijs = _koopprijs
        };
    }
}

public class ProjectBuilder
{
    private string _hoofdFoto = "Default.jpg";

    public ProjectBuilder WithHoofdFoto(string hoofdFoto)
    {
        _hoofdFoto = hoofdFoto;
        return this;
    }

    public Project Build()
    {
        return new Project
        {
            HoofdFoto = _hoofdFoto
        };
    }
}

public class PromoLabelBuilder
{
    private bool _hasPromotionLabel = false;
    private string _tagline = "Default Tagline";

    public PromoLabelBuilder WithHasPromotionLabel(bool hasPromotionLabel)
    {
        _hasPromotionLabel = hasPromotionLabel;
        return this;
    }

    public PromoLabelBuilder WithTagline(string tagline)
    {
        _tagline = tagline;
        return this;
    }

    public PromoLabel Build()
    {
        return new PromoLabel
        {
            HasPromotionLabel = _hasPromotionLabel,
            Tagline = _tagline
        };
    }
}

public class PagingBuilder
{
    private int _aantalPaginas = 1;
    private int _huidigePagina = 1;

    public PagingBuilder WithAantalPaginas(int aantalPaginas)
    {
        _aantalPaginas = aantalPaginas;
        return this;
    }

    public PagingBuilder WithHuidigePagina(int huidigePagina)
    {
        _huidigePagina = huidigePagina;
        return this;
    }

    public Paging Build()
    {
        return new Paging
        {
            AantalPaginas = _aantalPaginas,
            HuidigePagina = _huidigePagina
        };
    }
}