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
 public class C_Entretien_Piece
 {
  #region Données membres
  private int _id;
  private int? _pieceId;
  private int? _entretienId;
  private int? _quantite;
  private double? _prix;
  private double? _tva;
  #endregion
  #region Constructeurs
  public C_Entretien_Piece()
  { }
  public C_Entretien_Piece(int? pieceId_, int? entretienId_, int? quantite_, double? prix_, double? tva_)
  {
   pieceId = pieceId_;
   entretienId = entretienId_;
   quantite = quantite_;
   prix = prix_;
   tva = tva_;
  }
  public C_Entretien_Piece(int id_, int? pieceId_, int? entretienId_, int? quantite_, double? prix_, double? tva_)
   : this(pieceId_, entretienId_, quantite_, prix_, tva_)
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
  public int? pieceId
  {
   get { return _pieceId; }
   set { _pieceId = value; }
  }
  public int? entretienId
  {
   get { return _entretienId; }
   set { _entretienId = value; }
  }
  public int? quantite
  {
   get { return _quantite; }
   set { _quantite = value; }
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
