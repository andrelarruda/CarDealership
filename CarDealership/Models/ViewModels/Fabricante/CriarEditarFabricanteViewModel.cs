namespace CarDealership.Models.ViewModels.Fabricante
{
    public class CriarEditarFabricanteViewModel<T>
    {
        public bool Editar { get; set; } = false;
        public T Modelo { get; set; }
    }
}
