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
 public class C_Piece
 {
  #region Données membres
  private int _id;
  private string _nom;
  private string _fabricant;
  private double? _prix;
  private double? _tva;
  private int? _quantite;
  #endregion
  #region Constructeurs
  public C_Piece()
  { }
  public C_Piece(string nom_, string fabricant_, double? prix_, double? tva_, int? quantite_)
  {
   nom = nom_;
   fabricant = fabricant_;
   prix = prix_;
   tva = tva_;
   quantite = quantite_;
  }
  public C_Piece(int id_, string nom_, string fabricant_, double? prix_, double? tva_, int? quantite_)
   : this(nom_, fabricant_, prix_, tva_, quantite_)
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
  public string fabricant
  {
   get { return _fabricant; }
   set { _fabricant = value; }
  }
  public double? prix
  {
   get { return _prix; }
   set { _prix = value; }
  }
  public double? tva
  {
   get { return _tva; }
   set { _tva = value; }
  }
  public int? quantite
  {
   get { return _quantite; }
   set { _quantite = value; }
  }
  #endregion
 }
}
