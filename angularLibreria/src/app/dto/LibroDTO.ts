import { AutorDTO } from "./AutorDTO";



export interface LibroDTO {
  id: number;
  titulo: string;
  anho: number;
  genero: string;
  nroPaginas: number;
  autorId: number;
  autor: AutorDTO;
}

