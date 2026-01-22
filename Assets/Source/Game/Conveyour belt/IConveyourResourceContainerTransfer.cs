using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConveyourResourceContainerTransfer : IResourceContainerTransfer
{
    public ConveyourResource ConveyourResource { get; set; }
}