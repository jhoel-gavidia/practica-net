// SERVICIO DE COLABORADOR
// SIRVE PARA DEFINIR EL BACKEND
// MEDIANTE PETICIONES HTTP

import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Colaborador } from '../models/colaborador';

@Injectable({
  providedIn: 'root'
})

export class ColaboradorService {

    private url = 'https://localhost:7291/api/ColaboradorAPI/Listar';

    constructor(private http: HttpClient) {}

    listar(): Observable<Colaborador[]> {

        return this.http.get<Colaborador[]>(this.url);

    }
}