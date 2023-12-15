import * as z from "zod"

const ZOD_ERROR = {
  REQUIRED_ERROR: "Campo requerido",
  EMPTY_FIELD_ERROR: "Este campo no puede estar vacío",
  MIN_INPUT_LENGTH_ERROR: (minLength: number) =>
    `Este campo no puede terner MENOS de ${minLength} caracteres`,
  MAX_INPUT_LENGTH_ERROR: (maxLength: number) =>
    `Este campo no puede terner MAS de ${maxLength} caracteres`,
}

export const zodValidations = {
  validateString: ({
    maxLength,
    minLength,
  }: {
    maxLength: number
    minLength: number
  }) =>
    z
      .string({ required_error: ZOD_ERROR.REQUIRED_ERROR })
      .min(1, { message: ZOD_ERROR.EMPTY_FIELD_ERROR })
      .min(minLength, { message: ZOD_ERROR.MIN_INPUT_LENGTH_ERROR(minLength) })
      .max(maxLength, { message: ZOD_ERROR.MAX_INPUT_LENGTH_ERROR(maxLength) }),
}
