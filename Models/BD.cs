using System.Data.SqlClient;
using Dapper;


public static class BD 

{
public static string _connectionString = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato can)
    {
        string SQL = "INSERT INTO Candidato(FkPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) Values(@FkPartido, @Apellido, @Nombre, @FechaNacimiento, @Foto, @Postulacion)";
        using(SqlConnection bd = new SqlConnection(_connectionString)){
            bd.Execute(SQL, new{ Apellido = can.Apellido, FkPartido = can.FkPartido, Nombre = can.Nombre, FechaNacimiento = can.FechaNacimiento, Foto = can.Foto, Postulacion = can.Postulacion});
        }
        
    }
    public static int EliminarCandidato(int idCandidato)
    {
        int ElimCandidato = 0;
        string sql = "DELETE FROM Candidato WHERE idCandidato = @Candidato";
        using(SqlConnection bd = new SqlConnection(_connectionString)){
            ElimCandidato = bd.Execute(sql, new{Candidato = idCandidato });
        }
        return ElimCandidato;
    }
    public static Partido VerInfoPartido(int idPartido)
    {
        Partido Partido = null;
        using(SqlConnection bd = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Partido WHERE idPartido = @IdPartido";
            Partido = bd.QueryFirstOrDefault<Partido>(sql, new { IdPartido = idPartido });
        }
        return Partido;
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
        Candidato Candidato = null;
        using(SqlConnection bd = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Candidato";
            Candidato = bd.QueryFirstOrDefault<Candidato>(sql);
        }
        return Candidato;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> NomsPartido = null;
        using(SqlConnection bd = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Partido";
            NomsPartido = bd.Query<Partido>(sql).ToList();
        }
        return NomsPartido;
    }
    private static List<Candidato> ListaCandidatos=new List<Candidato>();
    public static List<Candidato> ListarCandidatos(int IdPartido){
        using (SqlConnection bd = new SqlConnection(_connectionString)){
            string sql="SELECT * FROM Candidato WHERE FkPartido=@IdPartido";
            ListaCandidatos= bd.Query<Candidato>(sql,new{IdPartido=IdPartido}).ToList();
        }
        return ListaCandidatos;
    }
}