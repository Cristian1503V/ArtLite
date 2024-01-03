"use client"

import React from "react"
import { createArtwork } from "@/api/actions"
import { cn } from "@/libs/utils"
import { zodResolver } from "@hookform/resolvers/zod"
import { Controller, useForm } from "react-hook-form"
import { useMutation } from "react-query"
import * as z from "zod"

import { zodValidations } from "@/config/zod-validate"
import { DropArea } from "@/components/create/drop-area"
import { TagsSelect } from "@/components/create/tags-select"
import { TitleWrapper } from "@/components/create/title-wrapper"
import { Icons } from "@/components/icons"

interface ArtworkCreateFormProps {
  tags: string[]
}

const formSchema = z.object({
  title: zodValidations.validateString({ maxLength: 30, minLength: 4 }),
  description: zodValidations.validateString({
    maxLength: 200,
    minLength: 0,
    optional: true,
  }),
  images: zodValidations.validateImages(),
  tags: zodValidations.validateTags(),
})

export type FormSchema = z.infer<typeof formSchema>

export function ArtworkCreateForm({ tags }: ArtworkCreateFormProps) {
  const form = useForm<FormSchema>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      title: "",
      description: "",
      tags: [],
      images: [],
    },
    mode: "onSubmit",
  })

  const {
    handleSubmit,
    control,
    register,
    watch,
    formState: { errors },
  } = form

  const { mutate, isLoading } = useMutation({
    mutationKey: ["Create", "Artwork"],
    mutationFn: (dataForm: FormSchema) => {
      console.log({ dataForm })
      const formData = new FormData()
      formData.append("title", dataForm.title)
      formData.append("description", dataForm.description)
      dataForm.tags.forEach((tag) => formData.append("tags", tag))
      dataForm.images.forEach((image) => formData.append("images", image))
      createArtwork(formData)
    },
    onError: () => {
      console.log("algo salio mal")
    },
    onSuccess: () => {
      console.log("El Andres programa muy chimba")
    },
  })

  const onSubmit = (dataForm: FormSchema) => {
    mutate(dataForm)
  }

  const watchTitle = watch("title")

  return (
    <div className="h-full  w-full">
      <h2 className="line-clamp-1 w-[500px] overflow-hidden px-4 text-[30px]">
        {watchTitle === "" ? "Untitled" : watchTitle}
      </h2>
      <form onSubmit={handleSubmit(onSubmit)} className="flex">
        <div className="flex h-full w-[70%] basis-[100%] flex-col gap-4">
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

            {errors.title && (
              <span className="text-xs text-red-400">
                {errors.title.message}
              </span>
            )}
          </TitleWrapper>

          <div className="flex h-full w-full flex-col">
            <Controller
              control={control}
              name="images"
              render={({ field: { onChange, onBlur, value } }) => (
                <DropArea
                  onChange={onChange}
                  onBlur={onBlur}
                  value={value}
                  name="images"
                />
              )}
            />

            {errors.images && (
              <span className="px-4 text-xs text-red-400">
                {errors.images.message}
              </span>
            )}
          </div>

          <div className="h-full w-full pt-6">
            <TitleWrapper title="Artwork Details">
              <label className="text-secondary-foreground text-[14px] font-semibold">
                Artwork Description
              </label>
              <textarea
                className={cn(
                  "bg-input text-foreground border-input-border  h-20 max-h-24 rounded-md border-[1px] px-3 py-2 text-[13px]  focus:outline-none",
                  errors.description && "border-red-400"
                )}
                {...register("description")}
                placeholder="Artwork Description"
              />

              {errors.description && (
                <span className="text-xs text-red-400">
                  {errors.description.message}
                </span>
              )}
            </TitleWrapper>
          </div>

          <div className="mb-32 h-full w-full">
            <TitleWrapper title="Tags">
              <Controller
                control={control}
                name="tags"
                render={({ field: { onChange, onBlur, value } }) => (
                  <TagsSelect
                    tags={tags}
                    onBlur={onBlur}
                    onChange={onChange}
                    value={value}
                    name="tags"
                  />
                )}
              />
              {errors.tags && (
                <span className="text-xs text-red-400">
                  {errors.tags.message}
                </span>
              )}
            </TitleWrapper>
          </div>
        </div>

        <div className="w-[30%]">
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
    </div>
  )
}
