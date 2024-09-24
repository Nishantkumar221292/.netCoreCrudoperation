using Dapper;
using PatientInformationAPI.DapperContext;
using PatientInformationAPI.Interface;
using PatientInformationAPI.Models;

namespace PatientInformationAPI.Repository;
public class DapperRepo : IDapperService
{
    private readonly DapperDbContext _dapperContext;
    public DapperRepo(DapperDbContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<string> CreateTask(PatientInformation patientInformation)
    {
        string response = String.Empty;
        var sql = "insert into patient(MobileNo, MRNo, oldfileNo, patientName, dob, hijriDOB, age, nationality,EmailID, registeredbranch, patientAddress, howDoYouHeardAboutUs) values(@MobileNo,@MRNo, @oldfileNo, @patientName, @dob, @hijriDOB, @age, @nationality, @EmailID, @registeredbranch, @patientAddress, @howDoYouHeardAboutUs)";
        var parameters = new DynamicParameters();
        //parameters.Add("idno", patientInformation.IdNo, System.Data.DbType.String);
        parameters.Add("MobileNo", patientInformation.MobileNo, System.Data.DbType.String);
        parameters.Add("MRNo", patientInformation.MRNo, System.Data.DbType.String);
        parameters.Add("oldfileNo", patientInformation.oldfileNo, System.Data.DbType.String);
        parameters.Add("patientName", patientInformation.PatientName, System.Data.DbType.String);
        parameters.Add("dob", patientInformation.DOB, System.Data.DbType.String);
        parameters.Add("hijriDOB", patientInformation.HijriDOB, System.Data.DbType.String);
        parameters.Add("age", patientInformation.Age, System.Data.DbType.String);
        parameters.Add("nationality", patientInformation.Nationality, System.Data.DbType.String);
        parameters.Add("EmailID", patientInformation.EmailID, System.Data.DbType.String);
        parameters.Add("registeredbranch", patientInformation.RegisteredBranch, System.Data.DbType.String);
        parameters.Add("patientAddress", patientInformation.PatientAddress, System.Data.DbType.String);
        parameters.Add("howDoYouHeardAboutUs", patientInformation.HowDoYouHeardAboutUs, System.Data.DbType.String);
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
            response = "pass";
        }
        return response;
    }

    public async Task<string> DeleteTask(int idno)
    {
        string response = String.Empty;
        var sql = "delete from patient where idno = @idno";
        using (var connection = _dapperContext.CreateConnection())
        {

            await connection.ExecuteAsync(sql, new { idno });
            response = "pass";
        }
        return response;
    }

    public async Task<List<PatientInformation>> GetAll()
    {
        var sql = "select * from patient";
        using (var connection = _dapperContext.CreateConnection())
        {
            var tasks = await connection.QueryAsync<PatientInformation>(sql);
            return tasks.ToList();
        }
    }

    public async Task<PatientInformation> GetTaskById(int idno)
    {
        var sql = "select * from patient where idno = @idno";
        using (var connection = _dapperContext.CreateConnection())
        {
            var task = await connection.QueryFirstOrDefaultAsync<PatientInformation>(sql, new { idno });
            return task;
        }
    }

    public async Task<string> UpdateTask(PatientInformation patientInformation)
    {
        string response = String.Empty;
        var sql = "update patient set MobileNo= @MobileNo, MRNo= @MRNo, oldfileNo= @oldfileNo, patientName= @patientName, dob= @dob, hijriDOB= @hijriDOB, age= @age, nationality= @nationality,EmailID = @EmailID, registeredbranch= @registeredbranch, patientAddress= @patientAddress, howDoYouHeardAboutUs= @howDoYouHeardAboutUs where idno=@idno";
        var parameters = new DynamicParameters();
        //parameters.Add("idno", patientInformation.IdNo, System.Data.DbType.Int32);
        parameters.Add("MobileNo", patientInformation.MobileNo, System.Data.DbType.String);
        parameters.Add("MRNo", patientInformation.MRNo, System.Data.DbType.String);
        parameters.Add("oldfileNo", patientInformation.oldfileNo, System.Data.DbType.String);
        parameters.Add("patientName", patientInformation.PatientName, System.Data.DbType.String);
        parameters.Add("dob", patientInformation.DOB, System.Data.DbType.String);
        parameters.Add("hijriDOB", patientInformation.HijriDOB, System.Data.DbType.String);
        parameters.Add("age", patientInformation.Age, System.Data.DbType.Int32);
        parameters.Add("nationality", patientInformation.Nationality, System.Data.DbType.String);
        parameters.Add("EmailID", patientInformation.EmailID, System.Data.DbType.String);
        parameters.Add("registeredbranch", patientInformation.RegisteredBranch, System.Data.DbType.String);
        parameters.Add("patientAddress", patientInformation.PatientAddress, System.Data.DbType.String);
        parameters.Add("howDoYouHeardAboutUs", patientInformation.HowDoYouHeardAboutUs, System.Data.DbType.String);
        using (var connection = _dapperContext.CreateConnection())
        {
            await connection.ExecuteAsync(sql, parameters);
            response = "pass";
        }
        return response;
    }

}
