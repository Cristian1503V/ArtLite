"use client"

import React from "react"
import { cn } from "@/libs/utils"
import { DevTool } from "@hookform/devtools"
import { zodResolver } from "@hookform/resolvers/zod"
import { FormProvider, useFieldArray, useForm } from "react-hook-form"
import * as z from "zod"

import { zodValidations } from "@/config/zod-validate"

import { DropArea } from "../drop-area"
import { Icons } from "../icons"
import TitleWrapper from "../title-wrapper"

const formSchema = z.object({
  title: zodValidations.validateString({ maxLength: 30, minLength: 4 }),
  description: zodValidations.validateString({ maxLength: 30, minLength: 4 }),
  images: z.custom<File>((v) => v instanceof File, {
    message: "Se requiere una imagen",
  }),
})

type FormSchema = z.infer<typeof formSchema>

export function ArtworkCreateForm() {
  const methods = useForm<FormSchema>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      title: "Hola como estas",
      description: "hdsfhghdsfghghdsjghjdshfghsdjk",
    },
  })

  const {
    register,
    handleSubmit,
    watch,
    control,
    formState: { errors },
  } = methods

  // const form = useForm<z.infer<typeof formSchema>>({
  //   resolver: zodResolver(formSchema),
  //   defaultValues: {
  //     title: "hola",
  //     description: "hkaoladff",
  //   },
  // })

  // const { fields, append, remove } = useFieldArray({
  //   name: "",
  //   control: form.control,
  // })

  // const { fields, remove } = useFieldArray({ control, name: "image" })

  const onSubmit = (dataForm: FormSchema) => {
    console.log({ dataForm })
  }

  const watchTitle = watch("title")

  return (
    <div className="h-full  w-full">
      <h2 className="line-clamp-1 w-[500px] overflow-hidden px-4 text-[30px]">
        {watchTitle === "" ? "Untitled" : watchTitle}
      </h2>
      <FormProvider {...methods}>
        <form onSubmit={handleSubmit(onSubmit)} className="flex">
          <div className="flex h-full w-[75%] basis-[100%] flex-col">
            <TitleWrapper title="Artwork Title">
              <input
                className={cn(
                  "bg-input text-foreground border-input-border rounded-md border-[1px] px-3 py-2 text-sm focus:outline-none",
                  errors.title && "border-red-400"
                )}
                type="text"
                {...register("title")}
                placeholder="What is your artwork called?"
              />

              <input
                className={cn(
                  "bg-input text-foreground border-input-border rounded-md border-[1px] px-3 py-2 text-sm focus:outline-none",
                  errors.description && "border-red-400"
                )}
                type="text"
                {...register("description")}
                placeholder="What is your artwork called?"
              />

              {errors.description && (
                <span className="text-xs text-red-400">
                  {errors.description.message}
                </span>
              )}

              {errors.title && (
                <span className="text-xs text-red-400">
                  {errors.title.message}
                </span>
              )}
            </TitleWrapper>

            <DropArea />

            <DevTool control={control} />

            {errors.images && (
              <span className="text-xs text-red-400">
                {errors.images.message}
              </span>
            )}
          </div>

          <div className="w-[25%]">
            <TitleWrapper title="Publishing Options">
              <span className="text-secondary-foreground text-[14px]">
                Publish status
              </span>
              <button
                className="text-accent-foreground  bg-accent hover:bg-accent-hover flex items-center justify-center gap-2 rounded-lg px-2 py-[10px] text-[14px] font-semibold leading-3 transition-all"
                type="submit"
              >
                <Icons.rocket className="h-5 w-5" />
                <span>Publish</span>
              </button>
            </TitleWrapper>
          </div>
        </form>
      </FormProvider>
    </div>
  )
}
