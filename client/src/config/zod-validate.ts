import * as z from "zod"

const ZOD_ERROR = {
  REQUIRED_ERROR: "This field is required",
  EMPTY_FIELD_ERROR: "This field cannot be empty",
  MIN_INPUT_LENGTH_ERROR: (minLength: number) =>
    `This field cannot be less than ${minLength} characters long`,
  MAX_INPUT_LENGTH_ERROR: (maxLength: number) =>
    `This field cannot be more than ${maxLength} characters long`,
  MAX_TAGS_LENGTH: "You cannot select more than 10 tags",
  REQUIRED_IMAGES: "At least one image is required",
}

export const zodValidations = {
  validateString: ({
    maxLength,
    minLength,
    optional = false,
  }: {
    maxLength: number
    minLength: number
    optional?: boolean
  }) => {
    const validate = z
      .string({ required_error: ZOD_ERROR.REQUIRED_ERROR })
      .min(minLength, { message: ZOD_ERROR.MIN_INPUT_LENGTH_ERROR(minLength) })
      .max(maxLength, { message: ZOD_ERROR.MAX_INPUT_LENGTH_ERROR(maxLength) })
    if (!optional) validate.min(1, { message: ZOD_ERROR.EMPTY_FIELD_ERROR })

    return validate
  },

  validateImages: () =>
    z
      .any()
      .array()
      // .refine((files) => files.length > 0, ZOD_ERROR.REQUIRED_IMAGES),
      .min(1, ZOD_ERROR.REQUIRED_IMAGES),

  validateTags: () => z.string().array().max(10, ZOD_ERROR.MAX_TAGS_LENGTH),
}
