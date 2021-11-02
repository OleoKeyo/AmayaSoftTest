using System.Collections;
using UnityEngine;

namespace AmayaTest.Infrastructure
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
  }
}