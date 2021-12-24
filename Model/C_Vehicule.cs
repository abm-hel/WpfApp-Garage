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
 public class C_Vehicule
 {
  #region Données membres
  private int _id;
  private int? _modeleId;
  private int? _clientId;
  private string _immatriculation;
  private DateTime? _datePremiereImmatriculation;
  private string _couleur;
  private Int64? _kilometrage;
  #endregion
  #region Constructeurs
  public C_Vehicule()
  { }
  public C_Vehicule(int? modeleId_, int? clientId_, string immatriculation_, DateTime? datePremiereImmatriculation_, string couleur_, Int64? kilometrage_)
  {
   modeleId = modeleId_;
   clientId = clientId_;
   immatriculation = immatriculation_;
   datePremiereImmatriculation = datePremiereImmatriculation_;
   couleur = couleur_;
   kilometrage = kilometrage_;
  }
  public C_Vehicule(int id_, int? modeleId_, int? clientId_, string immatriculation_, DateTime? datePremiereImmatriculation_, string couleur_, Int64? kilometrage_)
   : this(modeleId_, clientId_, immatriculation_, datePremiereImmatriculation_, couleur_, kilometrage_)
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
  public int? modeleId
  {
   get { return _modeleId; }
   set { _modeleId = value; }
  }
  public int? clientId
  {
   get { return _clientId; }
   set { _clientId = value; }
  }
  public string immatriculation
  {
   get { return _immatriculation; }
   set { _immatriculation = value; }
  }
  public DateTime? datePremiereImmatriculation
  {
   get { return _datePremiereImmatriculation; }
   set { _datePremiereImmatriculation = value; }
  }
  public string couleur
  {
   get { return _couleur; }
   set { _couleur = value; }
  }
  public Int64? kilometrage
  {
   get { return _kilometrage; }
   set { _kilometrage = value; }
  }
  #endregion
 }
}
