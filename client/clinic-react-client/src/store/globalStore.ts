import { create } from "zustand";
import { persist } from 'zustand/middleware';
import { immer } from 'zustand/middleware/immer';
import { devtools } from 'zustand/middleware';
import { OfficeSlice, getOfficeSlice } from "./officeStore";

export type GlobalState = OfficeSlice;

export const useGlobalStore = create<GlobalState>()(persist(devtools(immer((set, get, ...a) => ({
    ...getOfficeSlice(set, get, ...a),
  }))), { name: 'global-store' }));
