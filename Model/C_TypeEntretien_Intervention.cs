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
 public class C_TypeEntretien_Intervention
 {
  #region Données membres
  private int _id;
  private int? _interventionId;
  private int? _entretienId;
  private double? _prixHeure;
  private double? _prix;
  private double? _tva;
  #endregion
  #region Constructeurs
  public C_TypeEntretien_Intervention()
  { }
  public C_TypeEntretien_Intervention(int? interventionId_, int? entretienId_, double? prixHeure_, double? prix_, double? tva_)
  {
   interventionId = interventionId_;
   entretienId = entretienId_;
   prixHeure = prixHeure_;
   prix = prix_;
   tva = tva_;
  }
  public C_TypeEntretien_Intervention(int id_, int? interventionId_, int? entretienId_, double? prixHeure_, double? prix_, double? tva_)
   : this(interventionId_, entretienId_, prixHeure_, prix_, tva_)
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
  public int? interventionId
  {
   get { return _interventionId; }
   set { _interventionId = value; }
  }
  public int? entretienId
  {
   get { return _entretienId; }
   set { _entretienId = value; }
  }
  public double? prixHeure
  {
   get { return _prixHeure; }
   set { _prixHeure = value; }
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
  #endregion
 }
}
