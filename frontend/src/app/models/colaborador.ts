export interface Empresa {
    idEmpresa: number;
    razonSocial: string;
    ruc: string;
    direccion: string;
}

export interface Colaborador {
    idColaborador: number;
    name: string;
    lastName: string;
    idEmpresa: number;
    empresa: Empresa;
    fechaRegistro: string;
    fechaModificacion: string | null;
}