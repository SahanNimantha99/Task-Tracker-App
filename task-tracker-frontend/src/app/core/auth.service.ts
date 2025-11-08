import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';

interface LoginResponse { token: string; }

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'https://localhost:5001/api/auth';
  private tokenSubject = new BehaviorSubject<string | null>(localStorage.getItem('token'));
  token$ = this.tokenSubject.asObservable();

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, { username, password })
      .pipe(tap(res => {
        localStorage.setItem('token', res.token);
        this.tokenSubject.next(res.token);
      }));
  }

  logout() {
    localStorage.removeItem('token');
    this.tokenSubject.next(null);
  }

  getToken() { return this.tokenSubject.value; }
}
