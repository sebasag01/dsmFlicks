

using System;
using System.Text;
using System.Collections.Generic;

using ProyectoDSMGen.ApplicationCore.Exceptions;

using ProyectoDSMGen.ApplicationCore.EN.Flicks;
using ProyectoDSMGen.ApplicationCore.IRepository.Flicks;
using Newtonsoft.Json;


namespace ProyectoDSMGen.ApplicationCore.CEN.Flicks
{
/*
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorRepository _IAdministradorRepository;

public AdministradorCEN(IAdministradorRepository _IAdministradorRepository)
{
        this._IAdministradorRepository = _IAdministradorRepository;
}

public IAdministradorRepository get_IAdministradorRepository ()
{
        return this._IAdministradorRepository;
}

public int New_ (string p_nombre, string p_email, String p_pass)
{
        AdministradorEN administradorEN = null;
        int oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Nombre = p_nombre;

        administradorEN.Email = p_email;

        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);



        oid = _IAdministradorRepository.New_ (administradorEN);
        return oid;
}

public void Modify (int p_Administrador_OID, string p_nombre, string p_email, String p_pass)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Id = p_Administrador_OID;
        administradorEN.Nombre = p_nombre;
        administradorEN.Email = p_email;
        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to AdministradorRepository

        _IAdministradorRepository.Modify (administradorEN);
}

public string Login (int p_Administrador_OID, string p_pass)
{
        string result = null;
        AdministradorEN en = _IAdministradorRepository.ReadOIDDefault (p_Administrador_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Id);

        return result;
}

public void Destroy (int id
                     )
{
        _IAdministradorRepository.Destroy (id);
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorRepository.ReadAll (first, size);
        return list;
}
public AdministradorEN ReadID (int id
                               )
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorRepository.ReadID (id);
        return administradorEN;
}




private string Encode (int id)
{
        var payload = new Dictionary<string, object>(){
                { "id", id }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int id)
{
        AdministradorEN en = _IAdministradorRepository.ReadOIDDefault (id);
        string token = Encode (en.Id);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerID (decodedToken);

                AdministradorEN en = _IAdministradorRepository.ReadOIDDefault (id);

                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long id = (long)results ["id"];
                return id;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
