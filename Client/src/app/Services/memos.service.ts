import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'

import { Observable, of } from 'rxjs'
import { tap, catchError } from 'rxjs/operators'
import { memo } from '../Models/memos'
import { apiurl } from '../Models/apiurl';

const httpOption = {
  headers: new HttpHeaders({ 'content-type': 'application/JSON' })
};

@Injectable({
  providedIn: 'root'
})
export class MemosService {
  apiurl = `${apiurl.URL}/memos`
  constructor(private http: HttpClient) { }

  GetMemo(): Observable<memo[]> {
    return this.http.get<memo[]>(`${this.apiurl}`)
  }
  NewMemo(newmemo: memo): Observable<memo> {
    return this.http.post<memo>(`${this.apiurl}/new`, newmemo, httpOption)
  }
 
  DeleteMemo(Id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiurl}/delete/${Id}`);
  }
}
