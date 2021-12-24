#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Projet_Garage.Model
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class C_Client
 {
  #region Données membres
  private int _id;
  private string _nom;
  private string _prenom;
  private DateTime? _dateNaissance;
  private string _adresse;
  private string _numeroTelephone;
  private string _adresseEmail;
  #endregion
  #region Constructeurs
  public C_Client()
  { }
  public C_Client(string nom_, string prenom_, DateTime? dateNaissance_, string adresse_, string numeroTelephone_, string adresseEmail_)
  {
   nom = nom_;
   prenom = prenom_;
   dateNaissance = dateNaissance_;
   adresse = adresse_;
   numeroTelephone = numeroTelephone_;
   adresseEmail = adresseEmail_;
  }
  public C_Client(int id_, string nom_, string prenom_, DateTime? dateNaissance_, string adresse_, string numeroTelephone_, string adresseEmail_)
   : this(nom_, prenom_, dateNaissance_, adresse_, numeroTelephone_, adresseEmail_)
  {
   id = id_;
  }
  #endregion
  #region Accesseurs
  public int id
  {
   get { return _id; }
   set { _id = value; }
  }
  public string nom
  {
   get { return _nom; }
   set { _nom = value; }
  }
  public string prenom
  {
   get { return _prenom; }
   set { _prenom = value; }
  }
  public DateTime? dateNaissance
  {
   get { return _dateNaissance; }
   set { _dateNaissance = value; }
  }
  public string adresse
  {
   get { return _adresse; }
   set { _adresse = value; }
  }
  public string numeroTelephone
  {
   get { return _numeroTelephone; }
   set { _numeroTelephone = value; }
  }
  public string adresseEmail
  {
   get { return _adresseEmail; }
   set { _adresseEmail = value; }
  }
  #endregion
 }
}
