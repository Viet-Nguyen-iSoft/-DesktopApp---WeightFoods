using iSoft.Communication.Interface;
using iSoft.Communication.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Communication.EnumCommunication;

namespace iSoft.Communication.Preprocessing
{
  public static class ProcessingDataWeight
  {
    //public static MessageDataOutput? Processing(MessageDataInput messsage)
    //{
    //  MessageDataOutput messageDataOutput = new MessageDataOutput();
    //  double? _IndicatedWeight = null;

    //  messageDataOutput.unitOfWeight = UnitOfWeight.Kilograms;

    //  switch (messsage.eModeCommunication)
    //  {
    //    case eModeCommunication.SCOD:
    //      StandardContinuousOutputData newNontinuousOutputData = new StandardContinuousOutputData();
    //      var dataBytes = messsage.DataAsBytes;
    //      var len = dataBytes.Length;

    //      newNontinuousOutputData = StandardContinuousOutputData.Decode(dataBytes, false);
    //      _IndicatedWeight = newNontinuousOutputData.IndicatedWeight;

    //      if (messsage.eValueWeightType == eValueWeightType.Weight)
    //      {
    //        messageDataOutput.Value = (newNontinuousOutputData?.IndicatedWeight == null) ? 0 : newNontinuousOutputData.IndicatedWeight;
    //      }
    //      else
    //      {
    //        messageDataOutput.Value = (newNontinuousOutputData?.TareWeight == null) ? 0 : newNontinuousOutputData.TareWeight;
    //      }



    //      //if (continuousOutputData?.StatusB?.ActiveWeighingStatus != newNontinuousOutputData.StatusB.ActiveWeighingStatus)
    //      if (this.ActiveWeighingStatus != newNontinuousOutputData.StatusB.ActiveWeighingStatus)
    //        OnActiveWeighingStatusChangeEvent?.Invoke(this, newNontinuousOutputData.StatusB.ActiveWeighingStatus);

    //      this.continuousOutputData = newNontinuousOutputData;
    //      this.ActiveWeighingStatus = continuousOutputData.StatusB.ActiveWeighingStatus;


    //      messageDataOutput.unitOfWeight = newNontinuousOutputData.Unit;

    //      break;


    //    ///////////////////////////////
    //    case eModeCommunication.Continuous:
    //      // TOTO: 
    //      //var continuousFomatData = ContinuousFomatData.Decode(dataReceived.DataAsString);

    //      //if (continuousFomatData.Status != this.ActiveWeighingStatus)
    //      //{
    //      //  this.ActiveWeighingStatus = continuousFomatData.Status;
    //      //  OnActiveWeighingStatusChangeEvent?.Invoke(this, this.ActiveWeighingStatus);
    //      //}


    //      //_unit = continuousFomatData.Unit;
    //      //_IndicatedWeight = continuousFomatData.Indicated;
    //      break;
    //    case eModeCommunication.Digi:
    //      // TOTO: 
    //      //var digiFormatData = DigiFormatData.Decode(dataReceived.DataAsString);

    //      //if (digiFormatData.Status != this.ActiveWeighingStatus)
    //      //{
    //      //  this.ActiveWeighingStatus = digiFormatData.Status;
    //      //  OnActiveWeighingStatusChangeEvent?.Invoke(this, this.ActiveWeighingStatus);
    //      //}


    //      //_unit = digiFormatData.Unit;
    //      //_IndicatedWeight = digiFormatData.Indicated;

    //      break;
    //    case eModeCommunication.SICS:
    //      //var sicsFormatData = DigiFormatData.DecodeSICS(dataReceived.DataAsString);
    //      //if (sicsFormatData.Status != this.ActiveWeighingStatus)
    //      //{
    //      //  this.ActiveWeighingStatus = sicsFormatData.Status;
    //      //  OnActiveWeighingStatusChangeEvent?.Invoke(this, this.ActiveWeighingStatus);
    //      //}
    //      //_unit = sicsFormatData.Unit;
    //      //_IndicatedWeight = sicsFormatData.Indicated;
    //      break;
    //    default:
    //      break;
    //  }

    //  //switch (_unit)
    //  //{
    //  //  case UnitOfWeight.Kilograms:
    //  //    this.Unit = WeighingUnit.Kilograms;
    //  //    break;
    //  //  case UnitOfWeight.Grams:
    //  //    this.Unit = WeighingUnit.Grams;
    //  //    break;
    //  //  case UnitOfWeight.Pounds:
    //  //    this.Unit = WeighingUnit.Pounds;
    //  //    break;
    //  //  case UnitOfWeight.Ounces:
    //  //    this.Unit = WeighingUnit.Ounces;
    //  //    break;
    //  //  default:
    //  //    this.Unit = WeighingUnit.Kilograms;
    //  //    break;
    //  //}
    //  //receiveStopwatch.Restart();
    //  //LastRecievedData = DateTime.Now;
    //  //this.CountRecievedData++;
    //  //LastIndicatedWeight = _IndicatedWeight;

    //  //RecievedInterval.Enqueue(receiveStopwatch.Elapsed);
    //  //if (RecievedInterval.Count > 100)
    //  //  RecievedInterval.Dequeue();

    //  messageDataOutput.Source = messsage.Source;
    //  messageDataOutput.SourceDateTime = messsage.SourceDateTime;
    //  return messageDataOutput;
    //}
  }
}
