namespace Snip.BP.BO.Enums
{
    public enum EtapasLicitacion
    {
        ElaboracionTdR = 7,
        PublicacionPliego,
        RecepcionOfertas,
        AnalisisOfertas,
        Adjudicacion,
        FirmaContrato,
        Contratada,
        Cancelada,
        Desierta
    }

    public enum EstadoReprogramacion
    {
        EnRegistro = 16,
        PendienteRevision,
        Aprobada
    }
}