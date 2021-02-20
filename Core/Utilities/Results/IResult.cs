namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } //get okunabilir demek, amaç sadece okunmak ise get kullanılır
        string Message { get; } //bu da işlemin sonucunu kullanıcıya verebilmek için mesaj
    }
}
