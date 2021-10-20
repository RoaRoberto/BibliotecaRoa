import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";
import { CiudadDTO } from "./CiudadDTO";

export interface AutorDTO {
  id: number;
  nombreCompleto: string;
  fechaNacimiento: string;
  email: string;
  ciudadId: number;
  ciudad: CiudadDTO;
  dob: NgbDateStruct;
}
