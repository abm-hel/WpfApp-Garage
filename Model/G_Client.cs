#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using Projet_Garage.Model;
using Projet_Garage.Acces;
#endregion

namespace Projet_Garage.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_Client : G_Base
 {
  #region Constructeurs
  public G_Client()
   : base()
  { }
  public G_Client(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string nom, string prenom, DateTime? dateNaissance, string adresse, string numeroTelephone, string adresseEmail)
  { return new A_Client(ChaineConnexion).Ajouter(nom, prenom, dateNaissance, adresse, numeroTelephone, adresseEmail); }
  public int Modifier(int id, string nom, string prenom, DateTime? dateNaissance, string adresse, string numeroTelephone, string adresseEmail)
  { return new A_Client(ChaineConnexion).Modifier(id, nom, prenom, dateNaissance, adresse, numeroTelephone, adresseEmail); }
  public List<C_Client> Lire(string Index)
  { return new A_Client(ChaineConnexion).Lire(Index); }
  public C_Client Lire_ID(int id)
  { return new A_Client(ChaineConnexion).Lire_ID(id); }
  public int Supprimer(int id)
  { return new A_Client(ChaineConnexion).Supprimer(id); }
 }
}
