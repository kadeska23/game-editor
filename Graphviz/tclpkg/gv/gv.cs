/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 1.3.26
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace gv {

using System;
using System.Runtime.InteropServices;

public class gv {
  public static SWIGTYPE_p_Agraph_t graph(string name) {
    IntPtr cPtr = gvPINVOKE.graph__SWIG_0(name);
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t digraph(string name) {
    IntPtr cPtr = gvPINVOKE.digraph(name);
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t strictgraph(string name) {
    IntPtr cPtr = gvPINVOKE.strictgraph(name);
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t strictdigraph(string name) {
    IntPtr cPtr = gvPINVOKE.strictdigraph(name);
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t readstring(string string) {
    IntPtr cPtr = gvPINVOKE.readstring(string);
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t read(string filename) {
    IntPtr cPtr = gvPINVOKE.read__SWIG_0(filename);
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t read(SWIGTYPE_p_FILE f) {
    IntPtr cPtr = gvPINVOKE.read__SWIG_1(SWIGTYPE_p_FILE.getCPtr(f));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t graph(SWIGTYPE_p_Agraph_t g, string name) {
    IntPtr cPtr = gvPINVOKE.graph__SWIG_1(SWIGTYPE_p_Agraph_t.getCPtr(g), name);
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t node(SWIGTYPE_p_Agraph_t g, string name) {
    IntPtr cPtr = gvPINVOKE.node(SWIGTYPE_p_Agraph_t.getCPtr(g), name);
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t edge(SWIGTYPE_p_Agnode_t t, SWIGTYPE_p_Agnode_t h) {
    IntPtr cPtr = gvPINVOKE.edge__SWIG_0(SWIGTYPE_p_Agnode_t.getCPtr(t), SWIGTYPE_p_Agnode_t.getCPtr(h));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t edge(SWIGTYPE_p_Agnode_t t, string hname) {
    IntPtr cPtr = gvPINVOKE.edge__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(t), hname);
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t edge(string tname, SWIGTYPE_p_Agnode_t h) {
    IntPtr cPtr = gvPINVOKE.edge__SWIG_2(tname, SWIGTYPE_p_Agnode_t.getCPtr(h));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t edge(SWIGTYPE_p_Agraph_t g, string tname, string hname) {
    IntPtr cPtr = gvPINVOKE.edge__SWIG_3(SWIGTYPE_p_Agraph_t.getCPtr(g), tname, hname);
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static string setv(SWIGTYPE_p_Agraph_t g, string attr, string val) {
    string ret = gvPINVOKE.setv__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g), attr, val);
    return ret;
  }

  public static string setv(SWIGTYPE_p_Agnode_t n, string attr, string val) {
    string ret = gvPINVOKE.setv__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n), attr, val);
    return ret;
  }

  public static string setv(SWIGTYPE_p_Agedge_t e, string attr, string val) {
    string ret = gvPINVOKE.setv__SWIG_2(SWIGTYPE_p_Agedge_t.getCPtr(e), attr, val);
    return ret;
  }

  public static string setv(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agsym_t a, string val) {
    string ret = gvPINVOKE.setv__SWIG_3(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agsym_t.getCPtr(a), val);
    return ret;
  }

  public static string setv(SWIGTYPE_p_Agnode_t n, SWIGTYPE_p_Agsym_t a, string val) {
    string ret = gvPINVOKE.setv__SWIG_4(SWIGTYPE_p_Agnode_t.getCPtr(n), SWIGTYPE_p_Agsym_t.getCPtr(a), val);
    return ret;
  }

  public static string setv(SWIGTYPE_p_Agedge_t e, SWIGTYPE_p_Agsym_t a, string val) {
    string ret = gvPINVOKE.setv__SWIG_5(SWIGTYPE_p_Agedge_t.getCPtr(e), SWIGTYPE_p_Agsym_t.getCPtr(a), val);
    return ret;
  }

  public static string getv(SWIGTYPE_p_Agraph_t g, string attr) {
    string ret = gvPINVOKE.getv__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g), attr);
    return ret;
  }

  public static string getv(SWIGTYPE_p_Agnode_t n, string attr) {
    string ret = gvPINVOKE.getv__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n), attr);
    return ret;
  }

  public static string getv(SWIGTYPE_p_Agedge_t e, string attr) {
    string ret = gvPINVOKE.getv__SWIG_2(SWIGTYPE_p_Agedge_t.getCPtr(e), attr);
    return ret;
  }

  public static string getv(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agsym_t a) {
    string ret = gvPINVOKE.getv__SWIG_3(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agsym_t.getCPtr(a));
    return ret;
  }

  public static string getv(SWIGTYPE_p_Agnode_t n, SWIGTYPE_p_Agsym_t a) {
    string ret = gvPINVOKE.getv__SWIG_4(SWIGTYPE_p_Agnode_t.getCPtr(n), SWIGTYPE_p_Agsym_t.getCPtr(a));
    return ret;
  }

  public static string getv(SWIGTYPE_p_Agedge_t e, SWIGTYPE_p_Agsym_t a) {
    string ret = gvPINVOKE.getv__SWIG_5(SWIGTYPE_p_Agedge_t.getCPtr(e), SWIGTYPE_p_Agsym_t.getCPtr(a));
    return ret;
  }

  public static string nameof(SWIGTYPE_p_Agraph_t g) {
    string ret = gvPINVOKE.nameof__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
    return ret;
  }

  public static string nameof(SWIGTYPE_p_Agnode_t n) {
    string ret = gvPINVOKE.nameof__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n));
    return ret;
  }

  public static string nameof(SWIGTYPE_p_Agsym_t a) {
    string ret = gvPINVOKE.nameof__SWIG_2(SWIGTYPE_p_Agsym_t.getCPtr(a));
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t findsubg(SWIGTYPE_p_Agraph_t g, string name) {
    IntPtr cPtr = gvPINVOKE.findsubg(SWIGTYPE_p_Agraph_t.getCPtr(g), name);
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t findnode(SWIGTYPE_p_Agraph_t g, string name) {
    IntPtr cPtr = gvPINVOKE.findnode(SWIGTYPE_p_Agraph_t.getCPtr(g), name);
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t findedge(SWIGTYPE_p_Agnode_t t, SWIGTYPE_p_Agnode_t h) {
    IntPtr cPtr = gvPINVOKE.findedge(SWIGTYPE_p_Agnode_t.getCPtr(t), SWIGTYPE_p_Agnode_t.getCPtr(h));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t findattr(SWIGTYPE_p_Agraph_t g, string name) {
    IntPtr cPtr = gvPINVOKE.findattr__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g), name);
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t findattr(SWIGTYPE_p_Agnode_t n, string name) {
    IntPtr cPtr = gvPINVOKE.findattr__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n), name);
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t findattr(SWIGTYPE_p_Agedge_t e, string name) {
    IntPtr cPtr = gvPINVOKE.findattr__SWIG_2(SWIGTYPE_p_Agedge_t.getCPtr(e), name);
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t headof(SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.headof(SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t tailof(SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.tailof(SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t graphof(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.graphof__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t graphof(SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.graphof__SWIG_1(SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t graphof(SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.graphof__SWIG_2(SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t rootof(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.rootof(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t protonode(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.protonode(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t protoedge(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.protoedge(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static bool ok(SWIGTYPE_p_Agraph_t g) {
    bool ret = gvPINVOKE.ok__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
    return ret;
  }

  public static bool ok(SWIGTYPE_p_Agnode_t n) {
    bool ret = gvPINVOKE.ok__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n));
    return ret;
  }

  public static bool ok(SWIGTYPE_p_Agedge_t e) {
    bool ret = gvPINVOKE.ok__SWIG_2(SWIGTYPE_p_Agedge_t.getCPtr(e));
    return ret;
  }

  public static bool ok(SWIGTYPE_p_Agsym_t a) {
    bool ret = gvPINVOKE.ok__SWIG_3(SWIGTYPE_p_Agsym_t.getCPtr(a));
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t firstsubg(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.firstsubg(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t nextsubg(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agraph_t sg) {
    IntPtr cPtr = gvPINVOKE.nextsubg(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agraph_t.getCPtr(sg));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t firstsupg(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.firstsupg(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agraph_t nextsupg(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agraph_t sg) {
    IntPtr cPtr = gvPINVOKE.nextsupg(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agraph_t.getCPtr(sg));
    SWIGTYPE_p_Agraph_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agraph_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t firstedge(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.firstedge__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t nextedge(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.nextedge__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t firstout(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.firstout__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t nextout(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.nextout__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t firstedge(SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.firstedge__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t nextedge(SWIGTYPE_p_Agnode_t n, SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.nextedge__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n), SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t firstout(SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.firstout__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t nextout(SWIGTYPE_p_Agnode_t n, SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.nextout__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n), SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t firsthead(SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.firsthead(SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t nexthead(SWIGTYPE_p_Agnode_t n, SWIGTYPE_p_Agnode_t h) {
    IntPtr cPtr = gvPINVOKE.nexthead(SWIGTYPE_p_Agnode_t.getCPtr(n), SWIGTYPE_p_Agnode_t.getCPtr(h));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t firstin(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.firstin__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t nextin(SWIGTYPE_p_Agnode_t n, SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.nextin__SWIG_0(SWIGTYPE_p_Agnode_t.getCPtr(n), SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t firstin(SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.firstin__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agedge_t nextin(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.nextin__SWIG_1(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agedge_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agedge_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t firsttail(SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.firsttail(SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t nexttail(SWIGTYPE_p_Agnode_t n, SWIGTYPE_p_Agnode_t t) {
    IntPtr cPtr = gvPINVOKE.nexttail(SWIGTYPE_p_Agnode_t.getCPtr(n), SWIGTYPE_p_Agnode_t.getCPtr(t));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t firstnode(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.firstnode__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t nextnode(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.nextnode__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t firstnode(SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.firstnode__SWIG_1(SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agnode_t nextnode(SWIGTYPE_p_Agedge_t e, SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.nextnode__SWIG_1(SWIGTYPE_p_Agedge_t.getCPtr(e), SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agnode_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agnode_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t firstattr(SWIGTYPE_p_Agraph_t g) {
    IntPtr cPtr = gvPINVOKE.firstattr__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t nextattr(SWIGTYPE_p_Agraph_t g, SWIGTYPE_p_Agsym_t a) {
    IntPtr cPtr = gvPINVOKE.nextattr__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g), SWIGTYPE_p_Agsym_t.getCPtr(a));
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t firstattr(SWIGTYPE_p_Agedge_t e) {
    IntPtr cPtr = gvPINVOKE.firstattr__SWIG_1(SWIGTYPE_p_Agedge_t.getCPtr(e));
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t nextattr(SWIGTYPE_p_Agedge_t e, SWIGTYPE_p_Agsym_t a) {
    IntPtr cPtr = gvPINVOKE.nextattr__SWIG_1(SWIGTYPE_p_Agedge_t.getCPtr(e), SWIGTYPE_p_Agsym_t.getCPtr(a));
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t firstattr(SWIGTYPE_p_Agnode_t n) {
    IntPtr cPtr = gvPINVOKE.firstattr__SWIG_2(SWIGTYPE_p_Agnode_t.getCPtr(n));
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_Agsym_t nextattr(SWIGTYPE_p_Agnode_t n, SWIGTYPE_p_Agsym_t a) {
    IntPtr cPtr = gvPINVOKE.nextattr__SWIG_2(SWIGTYPE_p_Agnode_t.getCPtr(n), SWIGTYPE_p_Agsym_t.getCPtr(a));
    SWIGTYPE_p_Agsym_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Agsym_t(cPtr, false);
    return ret;
  }

  public static void rm(SWIGTYPE_p_Agraph_t g) {
    gvPINVOKE.rm__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
  }

  public static void rm(SWIGTYPE_p_Agnode_t n) {
    gvPINVOKE.rm__SWIG_1(SWIGTYPE_p_Agnode_t.getCPtr(n));
  }

  public static void rm(SWIGTYPE_p_Agedge_t e) {
    gvPINVOKE.rm__SWIG_2(SWIGTYPE_p_Agedge_t.getCPtr(e));
  }

  public static void layout(SWIGTYPE_p_Agraph_t g, string engine) {
    gvPINVOKE.layout(SWIGTYPE_p_Agraph_t.getCPtr(g), engine);
  }

  public static void render(SWIGTYPE_p_Agraph_t g) {
    gvPINVOKE.render__SWIG_0(SWIGTYPE_p_Agraph_t.getCPtr(g));
  }

  public static void render(SWIGTYPE_p_Agraph_t g, string format) {
    gvPINVOKE.render__SWIG_1(SWIGTYPE_p_Agraph_t.getCPtr(g), format);
  }

  public static void render(SWIGTYPE_p_Agraph_t g, string format, string filename) {
    gvPINVOKE.render__SWIG_2(SWIGTYPE_p_Agraph_t.getCPtr(g), format, filename);
  }

  public static void render(SWIGTYPE_p_Agraph_t g, string format, SWIGTYPE_p_FILE f) {
    gvPINVOKE.render__SWIG_3(SWIGTYPE_p_Agraph_t.getCPtr(g), format, SWIGTYPE_p_FILE.getCPtr(f));
  }

  public static void render(SWIGTYPE_p_Agraph_t g, string format, SWIGTYPE_p_p_void data) {
    gvPINVOKE.render__SWIG_4(SWIGTYPE_p_Agraph_t.getCPtr(g), format, SWIGTYPE_p_p_void.getCPtr(data));
  }

}

}
