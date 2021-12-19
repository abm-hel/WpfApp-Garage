#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Projet_Garage.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class C_Intervention
 {
  #region Données membres
  private int _id;
  private string _description;
  private int? _nombreHeures;
  private double? _prixHeure;
  private double? _tva;
  private double? _prixTotal;
  #endregion
  #region Constructeurs
  public C_Intervention()
  { }
  public C_Intervention(string description_, int? nombreHeures_, double? prixHeure_, double? tva_, double? prixTotal_)
  {
   description = description_;
   nombreHeures = nombreHeures_;
   prixHeure = prixHeure_;
   tva = tva_;
   prixTotal = prixTotal_;
  }
  public C_Intervention(int id_, string description_, int? nombreHeures_, double? prixHeure_, double? tva_, double? prixTotal_)
   : this(description_, nombreHeures_, prixHeure_, tva_, prixTotal_)
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
  public string description
  {
   get { return _description; }
   set { _description = value; }
  }
  public int? nombreHeures
  {
   get { return _nombreHeures; }
   set { _nombreHeures = value; }
  }
  public double? prixHeure
  {
   get { return _prixHeure; }
   set { _prixHeure = value; }
  }
  public double? tva
  {
   get { return _tva; }
   set { _tva = value; }
  }
  public double? prixTotal
  {
   get { return _prixTotal; }
   set { _prixTotal = value; }
  }
  #endregion
 }
}
