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
 public class C_Modele
 {
  #region Données membres
  private int _id;
  private string _modele;
  private string _motorisation;
  private string _carburant;
  private int? _cylindree;
  private int? _puissance;
  private double? _consommation;
  private int? _poids;
  #endregion
  #region Constructeurs
  public C_Modele()
  { }
  public C_Modele(string modele_, string motorisation_, string carburant_, int? cylindree_, int? puissance_, double? consommation_, int? poids_)
  {
   modele = modele_;
   motorisation = motorisation_;
   carburant = carburant_;
   cylindree = cylindree_;
   puissance = puissance_;
   consommation = consommation_;
   poids = poids_;
  }
  public C_Modele(int id_, string modele_, string motorisation_, string carburant_, int? cylindree_, int? puissance_, double? consommation_, int? poids_)
   : this(modele_, motorisation_, carburant_, cylindree_, puissance_, consommation_, poids_)
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
  public string modele
  {
   get { return _modele; }
   set { _modele = value; }
  }
  public string motorisation
  {
   get { return _motorisation; }
   set { _motorisation = value; }
  }
  public string carburant
  {
   get { return _carburant; }
   set { _carburant = value; }
  }
  public int? cylindree
  {
   get { return _cylindree; }
   set { _cylindree = value; }
  }
  public int? puissance
  {
   get { return _puissance; }
   set { _puissance = value; }
  }
  public double? consommation
  {
   get { return _consommation; }
   set { _consommation = value; }
  }
  public int? poids
  {
   get { return _poids; }
   set { _poids = value; }
  }
  #endregion
 }
}
