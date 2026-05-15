import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Colaborador } from '../models/colaborador';
import { ColaboradorService } from '../services/Colaborador.Service';

@Component({
  selector: 'app-panel',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.css']
})
export class PanelComponent implements OnInit {

  colaboradores: Colaborador[] = [];
  cargando = true;

  // Layout
  miniMode = false;
  submenuAbierto = true;

  constructor(private colaboradorService: ColaboradorService) {}

  ngOnInit(): void {
    this.listar();
  }

  listar(): void {
  console.log('llamando API...');
  this.colaboradorService.listar().subscribe({
    next: (data: Colaborador[]) => {
      console.log('data recibida:', data);
      this.colaboradores = data;
      this.cargando = false;
    },
    error: (err: any) => {
      console.error('error:', err);
      this.cargando = false;
    }
  });
}

  toggleMini(): void {
    this.miniMode = !this.miniMode;
  }

  toggleSubmenu(): void {
    this.submenuAbierto = !this.submenuAbierto;
  }
}